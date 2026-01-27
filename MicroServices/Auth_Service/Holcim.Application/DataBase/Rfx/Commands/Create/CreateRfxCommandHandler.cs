#nullable disable
#pragma warning disable CS8600, CS8602, CS8603, CS8604
using System;
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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;


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
        private readonly ILogger<CreateRfxCommandHandler> _logger;
        public CreateRfxCommandHandler(IDataBaseService dataBaseService, IMapper mapper,
            ICreateCorreoCommandHandler createCorreoCommandHandler, ICreateRfxPaisCommandHandler createRfxPaisCommandHandler, ICreateItemCommandHandler createItemCommandHandler,
            ICreateSobreCommandHandler createSobreCommandHandler, ICreateTrazabilidadCommandHandler createTrazabilidadCommandHandler,
            ICreateTrazabilidadCommandHandler createTrazabilidadCommandHandler1, ICreateInvitadosCommandHandler createInvitadosCommandHandler, ICreateCorreoRfxCommandHandler createCorreoRfxCommandHandler,
            ILogger<CreateRfxCommandHandler> logger)
        {
            _dataBaseService = dataBaseService!;
            _mapper = mapper!;
            _createCorreoCommandHandler = createCorreoCommandHandler!;
            _createRfxPaisCommandHandler = createRfxPaisCommandHandler!;
            _createItemCommandHandler = createItemCommandHandler!;
            _createSobreCommandHandler = createSobreCommandHandler!;
            _createTrazabilidadCommandHandler = createTrazabilidadCommandHandler!;
            _createInvitadosCommandHandler = createInvitadosCommandHandler!;
            _createCorreoRfxCommandHandler = createCorreoRfxCommandHandler!;
            _logger = logger ?? NullLogger<CreateRfxCommandHandler>.Instance;
        }

        public async Task<object> Execute(CreateRfxRequest createRfxRequest)
        {
            if (createRfxRequest == null)
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "Solicitud inválida");
            }

            var rfxSet = _dataBaseService.Rfx ?? throw new InvalidOperationException("Rfx DbSet no disponible");
            var nombreRfx = (createRfxRequest.Nombre ?? string.Empty).Trim();
            if (rfxSet.Any(x => (x.Nombre ?? string.Empty).Trim() == nombreRfx))
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, string.Empty, "Rfx Ya Registrado");
            }

            var entity = _mapper.Map<Domain.Entities.Rfx.Rfx>(createRfxRequest);
            entity.IdRfx = Guid.NewGuid();
            entity.EstadoId = createRfxRequest.EstadoId;
            entity.FechaCreacion = DateTime.Now;
            entity.FechaActulizacion = DateTime.Now;
            entity.Consecutivo = (rfxSet.Any() ? rfxSet.Max(x => x.Consecutivo) + 1 : 1);

            var usuarioEntity = _dataBaseService.Usuario!.FirstOrDefault(x => x.IdUsuario == createRfxRequest.UsuarioCreacion);
            var aprobador = usuarioEntity?.Aprobador;

            if (aprobador != null && aprobador.Value)
            {
                 var estadoAprobadoEntity = _dataBaseService.Estado!
                     .Include(x => x.TipoEstado)
                     .Where(x => x.TipoEstado.Descripcion == EnumDomain.rfx.GetEnumMemberValue() && x.Nombre == EnumDomain.RfxAprobado.GetEnumMemberValue())
                     .FirstOrDefault();

                if (estadoAprobadoEntity != null)
                {
                    entity.EstadoId = estadoAprobadoEntity.IdEstado;
                    createRfxRequest.EstadoId = entity.EstadoId;
                }
            }


            rfxSet.Add(entity);

            if (createRfxRequest.PaisId != null && createRfxRequest.PaisId.Any())
            {
                await _createRfxPaisCommandHandler.Execute(createRfxRequest.PaisId, entity.IdRfx);
            }
            await _createItemCommandHandler.Execute(createRfxRequest.CreateItemRequest, entity.IdRfx, createRfxRequest.CrearPregunta);
            if (createRfxRequest.ArchivoSobre is { Count: > 0 } archivoSobre)
            {
                await _createSobreCommandHandler.Execute(archivoSobre, entity.IdRfx);
            }
            await _createTrazabilidadCommandHandler.Execute(createRfxRequest, entity.IdRfx);
            await _dataBaseService.SaveAsync();


            var aprobadoEstadoEntity = _dataBaseService.Estado!
                .Where(x => x.Nombre == EnumDomain.RfxAprobado.GetEnumMemberValue().ToString())
                .FirstOrDefault();
            var proveedoresInvitados = createRfxRequest.ProveedoresInvitados;
            if (proveedoresInvitados != null && proveedoresInvitados.Count > 0 && aprobadoEstadoEntity != null &&
                createRfxRequest.EstadoId == aprobadoEstadoEntity.IdEstado)
            {

                var usuarioCreacion = await _dataBaseService.Usuario!
                    .Where(a => a.IdUsuario == createRfxRequest.UsuarioCreacion)
                    .FirstOrDefaultAsync();
                var dbZona = _dataBaseService.ZonaHoraria!.AsQueryable();
                var replacementsPorProveedor = new Dictionary<string, Dictionary<string, string>>();

                foreach (var provider in proveedoresInvitados)
                {
                    var dbProveedor = await _dataBaseService.Proveedor!.FirstOrDefaultAsync(a => a.Correo == provider);
                    if (dbProveedor == null)
                    {
                        await _createInvitadosCommandHandler.Execute(createRfxRequest, entity.IdRfx, aprobadoEstadoEntity.IdEstado);
                    }

                    var dataProveedor = await _dataBaseService.Proveedor.FirstOrDefaultAsync(a => a.Correo == provider);
                    if (dataProveedor == null)
                    {
                        continue;
                    }

                    var zonaNombre = dbZona.FirstOrDefault()?.Nombre ?? string.Empty;
                    var replacements = new Dictionary<string, string>
                   {
                       { "{0}", dataProveedor.NombreEmpresa ?? string.Empty },
                       { "{1}", entity.Nombre ?? string.Empty },
                       { "{2}", entity.FechaFinal.ToString() + zonaNombre},
                       { "{3}", usuarioCreacion?.Nombre ?? string.Empty },
                       { "{4}", usuarioCreacion?.Correo ?? string.Empty }
                   };
                    replacementsPorProveedor[provider] = replacements;
                }

                try
                {
                    await _createCorreoRfxCommandHandler.Execute(proveedoresInvitados, "Invitacion Holcim Rfx",
                       EnumDomain.InvitacionRfxProveedores.GetEnumMemberValue().ToString(), replacementsPorProveedor);
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, "Error enviando correos de invitación para Rfx {RfxId}", entity.IdRfx);
                    // Ignorar errores de envío de correo para no detener el proceso de creación.
                }
            }

            var estadoEntity = _dataBaseService.Estado.Include(x => x.TipoEstado)
                .Where(x => x.TipoEstado.Descripcion == EnumDomain.TipoEstadoProveedorRfx.GetEnumMemberValue() &&
                 x.Nombre == EnumDomain.PendienteRespuesta.GetEnumMemberValue()).FirstOrDefault();

            Guid estado = estadoEntity != null ? estadoEntity.IdEstado : Guid.Empty;
            createRfxRequest.IdRfx = entity.IdRfx;
            return ResponseApiService.Response(StatusCodes.Status201Created, createRfxRequest);

        }

    }
}

