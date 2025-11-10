using Holcim.Application.DataBase.Correo.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Models.Rfx;
using Holcim.Domain.Models.Rol;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Rfx.Commands.Update
{
    public class UpdateStateRfxCommandHandler : IUpdateStateRfxCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly ICreateCorreoCommandHandler _createCorreoCommandHandler;
        private readonly ICreateCorreoRfxCommandHandler _createCorreoRfxCommandHandler; 
        public UpdateStateRfxCommandHandler(IDataBaseService dataBaseService,
             ICreateCorreoCommandHandler createCorreoCommandHandler,
             ICreateCorreoRfxCommandHandler createCorreoRfxCommandHandler)
        {
            _dataBaseService = dataBaseService;
            _createCorreoCommandHandler = createCorreoCommandHandler;
            _createCorreoRfxCommandHandler = createCorreoRfxCommandHandler;
        }

        public async Task<object> Execute(RfxTrazabilidadRequest rfxTrazabilidadRequest)
        {

            Domain.Entities.Rfx.Rfx rfx = _dataBaseService.Rfx.Include(x => x.Estado)
                .Where(x => x.IdRfx == rfxTrazabilidadRequest.RfxId).First();

            if (rfx != null)
            {

                rfx.EstadoId = rfxTrazabilidadRequest.EstadoId;


                Domain.Entities.Rfx.TrazabilidadRfx trazabilidadRfx = new Domain.Entities.Rfx.TrazabilidadRfx();

                trazabilidadRfx.RfxId = rfx.IdRfx;
                trazabilidadRfx.EstadoId = rfxTrazabilidadRequest.EstadoId;
                trazabilidadRfx.FechaCambio = DateTime.Now;
                trazabilidadRfx.UsuarioId = rfxTrazabilidadRequest.UsuarioId;
                trazabilidadRfx.MotivoEstado = rfxTrazabilidadRequest.Motivo;

                _dataBaseService.TrazabilidadRfx.Add(trazabilidadRfx);


                Domain.Entities.Estado.Estado estado = _dataBaseService.Estado.Where(x => x.IdEstado == rfxTrazabilidadRequest.EstadoId).First();

                if (estado.Nombre == EnumDomain.RfxAprobado.GetEnumMemberValue())
                {
                    if (rfx.Estado.Nombre == EnumDomain.Suspendido.GetEnumMemberValue())
                    {
                        rfx.FechaFinal = rfxTrazabilidadRequest.FechaFinNew.Value;
                    }

                    List<Domain.Entities.ProveedorRfx.ProveedorRfx> Listproveedores = _dataBaseService.ProveedorRfx.
                        Where(x => x.RfxId == rfxTrazabilidadRequest.RfxId).ToList();
                    

                    InvitacionProveedorRfx invitacionProveedor = _dataBaseService.InvitacionProveedorRfx.
                        Where(x => x.RfxId == rfxTrazabilidadRequest.RfxId).First();

                    var dbUser = _dataBaseService.Usuario.AsQueryable();
                    var usuarioCreacion = await dbUser.Where(a => a.IdUsuario == rfx.UsuarioCreacion).FirstOrDefaultAsync();
                    var replacementsPorProveedor = new Dictionary<string, Dictionary<string, string>>();

                    foreach (var proveedorupdate in Listproveedores)
                    {
                        proveedorupdate.EstadoId = _dataBaseService.Estado.Where(x => x.Nombre == EnumDomain.PendienteAceptacion.GetEnumMemberValue()).
                            First().IdEstado;

                        _dataBaseService.ProveedorRfx.Update(proveedorupdate);
                        var proveedorData=await _dataBaseService.Proveedor.Where(a=>a.IdProveedor==proveedorupdate.ProveedorId).FirstOrDefaultAsync();
                        var proveedorname = await dbUser.Where(a => a.IdUsuario == proveedorData.UsuarioId).FirstOrDefaultAsync();
                        var replacements = new Dictionary<string, string>
                        {
                            { "{0}", proveedorname.Nombre.ToString() },
                            { "{1}", rfx.Nombre },
                            { "{2}",  rfx.FechaInicial.ToString()+"-"+rfx.FechaFinal.ToString()},
                            { "{3}",  usuarioCreacion.Nombre},
                            { "{4}", usuarioCreacion.Correo }
                         };
                        replacementsPorProveedor.Add(proveedorname.Correo,replacements);
                    }

                  

                    await _createCorreoRfxCommandHandler.Execute(JsonConvert.DeserializeObject<List<string>>(invitacionProveedor.Correo),
                    "Invitacion Holcim Rfx",
                    EnumDomain.InvitacionRfxProveedores.GetEnumMemberValue().ToString(), replacementsPorProveedor);

                }
                if (estado.Nombre == EnumDomain.Suspendido.GetEnumMemberValue())
                {
                    rfx.FechaInicial = rfxTrazabilidadRequest.FechaInicioNew.Value;
                    rfx.FechaFinal = rfxTrazabilidadRequest.FechaFinNew.Value;
                }

                _dataBaseService.Rfx.Update(rfx);

                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, rfxTrazabilidadRequest);

            }

            return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Rfx No Encontrado");

        }

    }
}
