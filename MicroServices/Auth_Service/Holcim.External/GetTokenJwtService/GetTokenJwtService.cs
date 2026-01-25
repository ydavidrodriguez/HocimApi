using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Holcim.Application;
using Holcim.Application.External.GettokenJwt;
using Holcim.Application.Feature;
using Holcim.Application.DataBase.Correo.Commands.Create;
using Holcim.Application.Helpers;
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
        private readonly ICreateCorreoCommandHandler _createCorreoCommandHandler;

        public GetTokenJwtService(IConfiguration config, IDataBaseService dataBaseService, ICreateCorreoCommandHandler createCorreoCommandHandler)
        {
            _config = config;
            _dataBaseService = dataBaseService;
            _createCorreoCommandHandler = createCorreoCommandHandler;
        }

        public object Execute(LoginUsuarioRequest loginUsuarioRequest)
        {

            var usuario = _dataBaseService.Usuario.Include(x=> x.Idioma)
                .Where(x => x.Correo == loginUsuarioRequest.Correo && x.Estado == true).FirstOrDefault();

            if (usuario != null && HelperPassword.Verify(loginUsuarioRequest.Contrasena, usuario.Contrasena))
            {
                usuario.UltimaConexion = DateTime.Now;
                _dataBaseService.Usuario.Update(usuario);

                var otpCode = HelperCorreo.CreateOtpCode(6);
                var now = DateTime.Now;
                var expiresAt = now.AddMinutes(10);

                var prevOtps = _dataBaseService.UsuarioOtp
                    .Where(x => x.UsuarioId == usuario.IdUsuario && !x.Usado)
                    .ToList();
                if (prevOtps.Any())
                {
                    foreach (var otp in prevOtps)
                    {
                        otp.Usado = true;
                    }
                }

                var usuarioOtp = new UsuarioOtp
                {
                    IdUsuarioOtp = Guid.NewGuid(),
                    UsuarioId = usuario.IdUsuario,
                    Codigo = otpCode,
                    FechaCreacion = now,
                    FechaExpiracion = expiresAt,
                    Usado = false
                };

                _dataBaseService.UsuarioOtp.Add(usuarioOtp);

                _dataBaseService.SaveAsync();

                var replacements = new Dictionary<string, string>
                {
                    { "{CODE}", otpCode },
                    { "{NOMBRE}", usuario.Nombre ?? string.Empty }
                };

                _createCorreoCommandHandler.Execute(
                    new List<string> { usuario.Correo },
                    "Código de verificación",
                    "2FA",
                    replacements);

                var pendingResponse = new TwoFactorPendingResponse
                {
                    IdUsuario = usuario.IdUsuario,
                    Correo = usuario.Correo,
                    ExpiraEn = expiresAt
                };

                return ResponseApiService.Response(StatusCodes.Status201Created, pendingResponse, "Código enviado");

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
