using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Usuario.Commands.Update
{
    public class UpdatePasswordUsuarioCommandHandler : IUpdatePasswordUsuarioCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdatePasswordUsuarioCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdatePasswordUsuario updatePasswordUsuario)
        {
            var usuario = _dataBaseService.Usuario.Where(x => x.IdUsuario == updatePasswordUsuario.UsuarioId).FirstOrDefault();

            if (usuario != null)
            {
                usuario.FechaActulizacion = DateTime.Now;
                usuario.Contrasena = updatePasswordUsuario.Contrasena.ToString();
                usuario.PrimerIngreso = false;

                _dataBaseService.Usuario.Update(usuario);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, null, "Contraseña Actulizada Corrrectamente");

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null,"Usuario No Registrado");
            }
        }

    }
}
