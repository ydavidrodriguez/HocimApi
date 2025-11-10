using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Usuario.Commands.Update
{
    public class UpdateUsuarioCommandHandler : IUpdateUsuarioCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdateUsuarioRequest updateUsuarioRequest)
        {
            var cuentaadmin = _dataBaseService.CuentaAdmin.Where(x => x.IdCuentaAdmin == updateUsuarioRequest.IdCuentaAdmin).FirstOrDefault();
            if (cuentaadmin != null)
            {
                cuentaadmin.PaisId = updateUsuarioRequest.PaisId;
                cuentaadmin.Estado = updateUsuarioRequest.Estado;

                _dataBaseService.CuentaAdmin.Update(cuentaadmin);


                Domain.Entities.Usuario.Usuario usuario = _dataBaseService.Usuario.Where(x => x.IdUsuario == cuentaadmin.UsuarioId).First();

                usuario.Nombre = updateUsuarioRequest.Nombre;
                usuario.Apellido = updateUsuarioRequest.Apellido;
                usuario.Estado = updateUsuarioRequest.EstadoUsuario;

                //lista de los roles que ya no deberia ir asociados 

                List<Domain.Entities.Rol.RolUsuario> rolUsuario1 =
                       _dataBaseService.RolUsuario
                       .Where(x => !updateUsuarioRequest.RolId.Contains(x.RolId)
                       && x.UsuarioId == usuario.IdUsuario).ToList();

                //elimina los roles ya no permitidos
                _dataBaseService.RolUsuario.RemoveRange(rolUsuario1);

                foreach (var item in updateUsuarioRequest.RolId)
                {
                    var usuariorol = _dataBaseService.
                        RolUsuario.Where(x => x.RolId == item && x.UsuarioId == usuario.IdUsuario).SingleOrDefault();

                    if (usuariorol == null)
                    {
                        Domain.Entities.Rol.RolUsuario rolUsuario = new Domain.Entities.Rol.RolUsuario();
                        rolUsuario.IdRolUsuario = Guid.NewGuid();
                        rolUsuario.UsuarioId = usuario.IdUsuario;
                        rolUsuario.RolId = item;

                        _dataBaseService.RolUsuario.Add(rolUsuario);

                    }

                }


                _dataBaseService.Usuario.Update(usuario);

                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, updateUsuarioRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "El usuario No se encuentra en la BD");
            }


        }

    }
}
