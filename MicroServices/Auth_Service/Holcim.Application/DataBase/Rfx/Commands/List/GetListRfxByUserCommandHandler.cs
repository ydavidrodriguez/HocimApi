using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public class GetListRfxByUserCommandHandler : IGetListRfxByUserCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;


        public GetListRfxByUserCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;

        }

        public async Task<object> Execute(Guid IdUsuario)
        {
            var rolusuario = _dataBaseService.RolUsuario
                .Include(x => x.Usuario)
                .Include(x => x.Rol)
                .Where(x => x.UsuarioId == IdUsuario).FirstOrDefault();

            List<Domain.Entities.Rfx.Rfx> rfxlist = new List<Domain.Entities.Rfx.Rfx>();

            if (rolusuario != null)
            {
                if (rolusuario.Rol.Nombre == EnumDomain.Generico.GetEnumMemberValue().ToString()
                    || rolusuario.Rol.Nombre == EnumDomain.Auditor.GetEnumMemberValue().ToString()
                    || rolusuario.Rol.Nombre == EnumDomain.Comprador.GetEnumMemberValue().ToString())
                {
                    rfxlist = _dataBaseService.UsuarioEncargadoRfx
                 .Include(x => x.Rfx)
                 .Include(x => x.Usuario)
                 .Where(x => x.UsuarioId == IdUsuario).Select(x => x.Rfx).Take(20).ToList();

                }
                else if (rolusuario.Rol.Nombre == EnumDomain.Proveedor.GetEnumMemberValue().ToString())
                {
                    rfxlist = _dataBaseService.ProveedorRfx
                    .Include(x => x.Rfx)
                    .Where(x => x.ProveedorId == IdUsuario).Select(x => x.Rfx).Take(20).ToList();
                }
                else if (rolusuario.Rol.Nombre == EnumDomain.AdministradorRegional.GetEnumMemberValue().ToString())
                {
                    var cuentaadmin = _dataBaseService.CuentaAdmin.Include(x => x.Pais).Where(x => x.UsuarioId == IdUsuario)
                        .FirstOrDefault();
                    rfxlist = _dataBaseService.RfxPais.Include(x => x.Pais)
                       .Where(x => x.Pais.RegionId == cuentaadmin.Pais.RegionId || x.Rfx.UsuarioCreacion == IdUsuario).Select(x => x.Rfx).Take(20).ToList();

                }
                else if (rolusuario.Rol.Nombre == EnumDomain.AdministradorGlobal.GetEnumMemberValue().ToString() || rolusuario.Rol.Nombre == EnumDomain.AdministradorSistema.GetEnumMemberValue().ToString())
                {
                    rfxlist = _dataBaseService.Rfx.Take(20).ToList();
                }

            }

            return ResponseApiService.Response(StatusCodes.Status201Created, rfxlist);

        }


    }
}
