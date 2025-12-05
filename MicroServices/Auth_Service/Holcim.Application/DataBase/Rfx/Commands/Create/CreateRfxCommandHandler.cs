using AutoMapper;
using Holcim.Application.DataBase.Correo.Commands.Create;
using Holcim.Application.DataBase.Invitados.Commands.Create;
using Holcim.Application.DataBase.Item.Commands.Create;
using Holcim.Application.DataBase.Pais.Commands.Create;
using Holcim.Application.DataBase.Sobre.Commands.Create;
using Holcim.Application.DataBase.TrazabilidadRfx.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Rfx.Commands.Create
{
    public class CreateRfxCommandHandler : ICreateRfxCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly ICreateCorreoCommandHandler _createCorreoCommandHandler;
        private readonly ICreateRfxPaisCommandHandler _createRfxPaisCommandHandler;
        private readonly ICreateItemCommandHandler _createItemCommandHandler;
        private readonly ICreateSobreCommandHandler _createSobreCommandHandler;
        private readonly ICreateTrazabilidadCommandHandler _createTrazabilidadCommandHandler;
        private readonly ICreateInvitadosCommandHandler _createInvitadosCommandHandler;
        private readonly ICreateCorreoRfxCommandHandler _createCorreoRfxCommandHandler;
        public CreateRfxCommandHandler(IDataBaseService dataBaseService, IMapper mapper,
            ICreateCorreoCommandHandler createCorreoCommandHandler, ICreateRfxPaisCommandHandler createRfxPaisCommandHandler, ICreateItemCommandHandler createItemCommandHandler,
            ICreateSobreCommandHandler createSobreCommandHandler, ICreateTrazabilidadCommandHandler createTrazabilidadCommandHandler,
            ICreateTrazabilidadCommandHandler createTrazabilidadCommandHandler1, ICreateInvitadosCommandHandler createInvitadosCommandHandler, ICreateCorreoRfxCommandHandler createCorreoRfxCommandHandler)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _createCorreoCommandHandler = createCorreoCommandHandler;
            _createRfxPaisCommandHandler = createRfxPaisCommandHandler;
            _createItemCommandHandler = createItemCommandHandler;
            _createSobreCommandHandler = createSobreCommandHandler;
            _createTrazabilidadCommandHandler = createTrazabilidadCommandHandler;
            _createInvitadosCommandHandler = createInvitadosCommandHandler;
            _createCorreoRfxCommandHandler = createCorreoRfxCommandHandler;
        }

        public async Task<object> Execute(CreateRfxRequest createRfxRequest)
        {
            if (_dataBaseService.Rfx.Any(x => x.Nombre.Trim() == createRfxRequest.Nombre.Trim()))
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Rfx Ya Registrado");
            }

            var entity = _mapper.Map<Domain.Entities.Rfx.Rfx>(createRfxRequest);
            entity.IdRfx = Guid.NewGuid();
            entity.EstadoId = createRfxRequest.EstadoId;
            entity.FechaCreacion = DateTime.Now;
            entity.FechaActulizacion = DateTime.Now;
            entity.Consecutivo = (_dataBaseService.Rfx.Any() ? _dataBaseService.Rfx.Max(x => x.Consecutivo) + 1 : 1);

            var aprobador = _dataBaseService.Usuario.Where(x => x.IdUsuario == createRfxRequest.UsuarioCreacion).FirstOrDefault().Aprobador;

            if (aprobador != null && aprobador.Value)
            {
                entity.EstadoId = _dataBaseService.Estado
                    .Include(x => x.TipoEstado)
                    .Where(x => x.TipoEstado.Descripcion == EnumDomain.rfx.GetEnumMemberValue() && x.Nombre == EnumDomain.RfxAprobado.GetEnumMemberValue()).FirstOrDefault().IdEstado;
                createRfxRequest.EstadoId = entity.EstadoId;
            }


            _dataBaseService.Rfx.Add(entity);

            await _createRfxPaisCommandHandler.Execute(createRfxRequest.PaisId, entity.IdRfx);
            await _createItemCommandHandler.Execute(createRfxRequest.CreateItemRequest, entity.IdRfx, createRfxRequest.CrearPregunta);
            await _createSobreCommandHandler.Execute(createRfxRequest.ArchivoSobre, entity.IdRfx);
            await _createTrazabilidadCommandHandler.Execute(createRfxRequest, entity.IdRfx);
            await _dataBaseService.SaveAsync();


            if (createRfxRequest.ProveedoresInvitados != null &&
                createRfxRequest.EstadoId == _dataBaseService.Estado.Where(x => x.Nombre == EnumDomain.RfxAprobado.GetEnumMemberValue().ToString()).First().IdEstado)
            {
                //TimeZoneInfo zonaOrigen = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

                //TimeZoneInfo zonaDestino = TimeZoneInfo.Utc;

                //// Convertir la fecha de Japón a UTC
                //DateTime fechaDestino = TimeZoneInfo.ConvertTime(entity.FechaFinal, zonaOrigen, zonaDestino);

                var dbUser = _dataBaseService.Usuario.AsQueryable();
                var usuarioCreacion = await dbUser.Where(a => a.IdUsuario == createRfxRequest.UsuarioCreacion).FirstOrDefaultAsync();
                var dbZona = _dataBaseService.ZonaHoraria.AsQueryable();
                var replacementsPorProveedor = new Dictionary<string, Dictionary<string, string>>();

                //foreach(var provider in createRfxRequest.ProveedoresInvitados)
                //{
                //    var dbProveedor =  _dataBaseService.Proveedor.AsQueryable();
                //    var dataProveedor = await _dataBaseService.Proveedor.Where(a => a.Correo == provider).FirstOrDefaultAsync();
                //    var zonaHoraria = await dbZona.Where(a => a.IdZonaHoraria == dataProveedor.ZonaHorariaId).FirstOrDefaultAsync();
                //    var userProveedor = await dbUser.Where(a => a.IdUsuario == dataProveedor.UsuarioId).FirstOrDefaultAsync();


                //    var replacements = new Dictionary<string, string>
                //    {
                //        { "{0}", userProveedor.Nombre.ToString() },
                //        { "{1}", entity.Nombre },
                //        { "{2}", entity.FechaFinal.ToString() + zonaHoraria.Nombre.ToString()},
                //        { "{3}", usuarioCreacion.Nombre.ToString() },
                //        { "{4}", usuarioCreacion.Correo.ToString() }
                //    };
                //    replacementsPorProveedor.Add(provider, replacements);
                //}



                //await _createCorreoRfxCommandHandler.Execute(createRfxRequest.ProveedoresInvitados, "Invitacion Holcim Rfx",
                //    EnumDomain.InvitacionRfxProveedores.GetEnumMemberValue().ToString(), replacementsPorProveedor);
            }

            Guid estado = _dataBaseService.Estado.Include(x => x.TipoEstado)
                 .Where(x => x.TipoEstado.Descripcion == EnumDomain.TipoEstadoProveedorRfx.GetEnumMemberValue() &&
                  x.Nombre == EnumDomain.PendienteRespuesta.GetEnumMemberValue()).First().IdEstado;

            await _createInvitadosCommandHandler.Execute(createRfxRequest, entity.IdRfx, estado);


            createRfxRequest.IdRfx = entity.IdRfx;



            return ResponseApiService.Response(StatusCodes.Status201Created, createRfxRequest);

        }

    }
}
