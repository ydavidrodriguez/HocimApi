using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public class ListUsuarioCommandHandler : IListUsuarioCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListUsuarioCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public object Execute(string? Nombre, string? Correo)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                List<UsuarioFilterResponse> cuentaAdmin = _dataBaseService.CuentaAdmin.
                     Include(x => x.Usuario)
                    .Include(x => x.Usuario.TipoUsuario)
                    .Where(x => x.Usuario.Nombre.Contains(Nombre))
                    .Select(x =>
                     new UsuarioFilterResponse
                     {
                         IdCuentaAdmin = x.IdCuentaAdmin,
                         Pais = x.Pais,
                         PaisId = x.PaisId,
                         UltimaConexion = x.Usuario.UltimaConexion,
                         Usuario = _mapper.Map<Domain.Models.Usuario.GetUsuarioResponse>(x.Usuario),
                         Rol = _dataBaseService.RolUsuario.Include(y => y.Rol).Where(y => y.UsuarioId == x.UsuarioId)
                         .Select(y => y.Rol).ToList(),
                     }
                ).ToList();


                return ResponseApiService.Response(StatusCodes.Status201Created, cuentaAdmin);

            }
            else if (!string.IsNullOrEmpty(Correo))
            {

                List<UsuarioFilterResponse> cuentaAdmin = _dataBaseService.CuentaAdmin.
                      Include(x => x.Usuario)
                     .Where(x => x.Usuario.Correo.Contains(Correo))
                     .Select(x =>
                      new UsuarioFilterResponse
                      {
                          IdCuentaAdmin = x.IdCuentaAdmin,
                          Pais = x.Pais,
                          PaisId = x.PaisId,
                          Usuario = _mapper.Map<Domain.Models.Usuario.GetUsuarioResponse>(x.Usuario),
                          UltimaConexion = x.Usuario.UltimaConexion,
                          Rol = _dataBaseService.RolUsuario.Include(y => y.Rol).Where(y => y.UsuarioId == x.UsuarioId).Select(y => y.Rol).ToList(),
                      }
                      ).ToList();

                return ResponseApiService.Response(StatusCodes.Status201Created, cuentaAdmin);
            }
            else if (string.IsNullOrEmpty(Nombre) && string.IsNullOrEmpty(Correo))
            {

                List<UsuarioFilterResponse> cuentaAdmin = _dataBaseService.CuentaAdmin.
                    Include(x => x.Usuario)
                   .Include(x => x.Usuario.TipoUsuario)
                   .Where(x => x.Usuario.TipoUsuario.Nombre == EnumDomain.TipoUsuarioHolcim.GetEnumMemberValue())
                   .Select(x =>
                    new UsuarioFilterResponse
                    {
                        IdCuentaAdmin = x.IdCuentaAdmin,
                        Pais = x.Pais,
                        PaisId = x.PaisId,
                        UltimaConexion = x.Usuario.UltimaConexion,
                        Usuario = _mapper.Map<Domain.Models.Usuario.GetUsuarioResponse>(x.Usuario),
                        Rol = _dataBaseService.RolUsuario.Include(y => y.Rol).Where(y => y.UsuarioId == x.UsuarioId)
                        .Select(y => y.Rol).ToList(),

                    }
                    ).ToList();

                return ResponseApiService.Response(StatusCodes.Status201Created, cuentaAdmin);
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, null, "Sin Datos");
            }

        }


    }
}
