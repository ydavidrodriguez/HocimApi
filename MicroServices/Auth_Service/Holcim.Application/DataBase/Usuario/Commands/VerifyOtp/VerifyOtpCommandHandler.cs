using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Usuario;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Holcim.Application.DataBase.Usuario.Commands.VerifyOtp
{
    public class VerifyOtpCommandHandler : IVerifyOtpCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IConfiguration _configuration;

        public VerifyOtpCommandHandler(IDataBaseService dataBaseService, IConfiguration configuration)
        {
            _dataBaseService = dataBaseService;
            _configuration = configuration;
        }

        public async Task<object> Execute(VerifyOtpRequest request)
        {
            var usuario = await _dataBaseService.Usuario
                .Include(x => x.Idioma)
                .FirstOrDefaultAsync(x => x.Correo == request.Correo && x.Estado == true);

            if (usuario == null)
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Usuario no válido");
            }

            var otp = await _dataBaseService.UsuarioOtp
                .Where(x => x.UsuarioId == usuario.IdUsuario && !x.Usado && x.FechaExpiracion >= DateTime.Now)
                .OrderByDescending(x => x.FechaCreacion)
                .FirstOrDefaultAsync();

            if (otp == null || !string.Equals(otp.Codigo, request.Codigo, StringComparison.Ordinal))
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Código inválido o expirado");
            }

            otp.Usado = true;
            _dataBaseService.UsuarioOtp.Update(otp);

            var token = CreateJwt(usuario.Correo);

            var usuarioToken = new UsuarioToken
            {
                IdUsuarioToken = Guid.NewGuid(),
                Idusuario = usuario.IdUsuario,
                Token = token,
                Estado = true,
                FechaCreacion = DateTime.Now
            };

            _dataBaseService.UsuarioToken.Add(usuarioToken);
            await _dataBaseService.SaveAsync();

            var response = new GetTokenUsuarioResponse
            {
                Token = token,
                IdUsuario = usuario.IdUsuario,
                Idioma = usuario.Idioma?.Key.ToString() ?? string.Empty
            };

            return ResponseApiService.Response(StatusCodes.Status201Created, response);
        }

        private string CreateJwt(string correo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, correo),
                new Claim(ClaimTypes.Name, correo)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
