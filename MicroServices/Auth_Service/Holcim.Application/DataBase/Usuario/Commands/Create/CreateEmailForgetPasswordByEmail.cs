using AutoMapper;
using Holcim.Application.DataBase.Correo.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Usuario.Commands.Create
{
    public class CreateEmailForgetPasswordByEmail : ICreateEmailForgetPasswordByEmail
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly ICreateCorreoCommandHandler _createCorreoCommandHandler;

        public CreateEmailForgetPasswordByEmail(IDataBaseService dataBaseService, IMapper mapper, ICreateCorreoCommandHandler createCorreoCommandHandler)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _createCorreoCommandHandler = createCorreoCommandHandler;

        }

        public object Execute(string correouser)
        {
            var usuario = _dataBaseService.Usuario.Where(x => x.Correo == correouser).FirstOrDefault();


            if (usuario != null)
            {

                usuario.PrimerIngreso = true;
                _dataBaseService.Usuario.Update(usuario);

                //_createCorreoCommandHandler.Execute(createEmailRequest);

                var replacements = new Dictionary<string, string>
                {
                    { "{0}", usuario.Nombre },
                    { "{1}", usuario.Contrasena }
                };

                _createCorreoCommandHandler.Execute(new List<string> { usuario.Correo }, "Recuperacion Contraseña Holcim",
                   EnumDomain.ActualizacionContrasena.GetEnumMemberValue().ToString().Trim(),
                   replacements);


                _dataBaseService.SaveAsync();


                return ResponseApiService.Response(StatusCodes.Status201Created, null, "correo enviado correctame");

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Usuario no encontrado en el sistema");
            }

        }

    }
}
