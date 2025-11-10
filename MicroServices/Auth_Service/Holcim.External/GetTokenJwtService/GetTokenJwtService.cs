using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Holcim.Application;
using Holcim.Application.External.GettokenJwt;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Usuario;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Holcim.External.GetTokenJwtService
{
    public class GetTokenJwtService : IGettokenJwt
    {
        private readonly IConfiguration _config;
        private readonly IDataBaseService _dataBaseService;
        public GetTokenJwtService(IConfiguration config, IDataBaseService dataBaseService)
        {
            _config = config;
            _dataBaseService = dataBaseService;
        }

        public object Execute(LoginUsuarioRequest loginUsuarioRequest)
        {

            var usuario = _dataBaseService.Usuario.Include(x=> x.Idioma)
                .Where(x => x.Correo == loginUsuarioRequest.Correo && x.Contrasena == loginUsuarioRequest.Contrasena && x.Estado == true).FirstOrDefault();

            if (usuario != null)
            {
                usuario.UltimaConexion = DateTime.Now;
                _dataBaseService.Usuario.Update(usuario);

                string tokefinal = getoken(loginUsuarioRequest);

                UsuarioToken usuarioToken = new UsuarioToken();

                usuarioToken.IdUsuarioToken = Guid.NewGuid();
                usuarioToken.Idusuario = usuario.IdUsuario;
                usuarioToken.Token = tokefinal;
                usuarioToken.Estado = true;
                usuarioToken.FechaCreacion = DateTime.Now;

                _dataBaseService.UsuarioToken.Add(usuarioToken);

                _dataBaseService.SaveAsync();

                GetTokenUsuarioResponse getTokenUsuarioResponse = new GetTokenUsuarioResponse();

                getTokenUsuarioResponse.Token = tokefinal;
                getTokenUsuarioResponse.IdUsuario = usuario.IdUsuario;
                getTokenUsuarioResponse.Idioma = usuario.Idioma.Key.ToString();



                return ResponseApiService.Response(StatusCodes.Status201Created, getTokenUsuarioResponse);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Lo sentimos, pero el usuario o la contraseña que ingresaste no coinciden con nuestros registros. Por favor, verifica tus datos.");

            }


        }
        public string getoken(LoginUsuarioRequest loginUsuarioRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,loginUsuarioRequest.Correo),
                new Claim(ClaimTypes.Name, loginUsuarioRequest.Correo),

            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            string tokefinal = new JwtSecurityTokenHandler().WriteToken(token);
            return tokefinal;

        }




    }
}
