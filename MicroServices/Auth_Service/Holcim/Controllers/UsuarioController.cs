using Holcim.Application.DataBase.Usuario.Commands.Create;
using Holcim.Application.DataBase.Usuario.Commands.List;
using Holcim.Application.DataBase.Usuario.Commands.Update;
using Holcim.Application.Exception;
using Holcim.Application.External.GettokenJwt;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("PostCreateUsuario")]
        public async Task<IActionResult> PostCreateUsuario(
            [FromServices] ICreateUsuarioCommandHandler CreateUsuarioCommandHandler, [FromBody] CreateUsuarioRequest CreateUsuarioRequest)
        {
            return Ok(await CreateUsuarioCommandHandler.Execute(CreateUsuarioRequest));
        }

        [HttpPut("PutUpdateUsuario")]
        public async Task<IActionResult> PutUpdateUsuario(
            [FromServices] IUpdateUsuarioCommandHandler UpdateUsuarioCommandHandler, [FromBody] UpdateUsuarioRequest UpdateUsuarioRequest)
        {
            return Ok(await UpdateUsuarioCommandHandler.Execute(UpdateUsuarioRequest));
        }

        [HttpGet("GetListUsuarioAll")]
        public async Task<IActionResult> GetListUsuarioAll(
          [FromServices] IListUsuarioCommandHandler ListUsuarioCommandHandler, [FromQuery] string? Nombre, [FromQuery] string? Correo)
        {
            return Ok(ListUsuarioCommandHandler.Execute(Nombre, Correo));
        }

        [HttpGet("GetUsuarioById")]
        public async Task<IActionResult> GetUsuarioById(
          [FromServices] IListUsuarioByIdCommandHandler ListUsuarioByIdCommandHandler, [FromQuery] Guid IdUsuario)
        {
            return Ok(ListUsuarioByIdCommandHandler.Execute(IdUsuario));

        }
        [HttpPut("PutUpdateUserPaswword")]
        public async Task<IActionResult> PutUpdateUserPaswword(
          [FromServices] IUpdatePasswordUsuarioCommandHandler updatePasswordUsuarioCommandHandler, [FromBody] UpdatePasswordUsuario updatePasswordUsuario)
        {
            return Ok(await updatePasswordUsuarioCommandHandler.Execute(updatePasswordUsuario));
        }
        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] LoginUsuarioRequest LoginUsuarioRequest,
        [FromServices] IGettokenJwt GettokenJwt)
        {
            return Ok(GettokenJwt.Execute(LoginUsuarioRequest));
        }
        [HttpGet("GetListUsuarioToken")]
        public async Task<IActionResult> GetListUsuarioToken(
        [FromServices] IGetUsuarioToken GetUsuarioToken, [FromQuery] Guid IdUsuario)
        {
            var data = await GetUsuarioToken.Execute(IdUsuario);
            if (data != null) { return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data)); }
            else { return StatusCode(StatusCodes.Status202Accepted, ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Usuario  No Valido")); }
        }
        [HttpGet("GetForgetPasswordByEmail")]
        public async Task<IActionResult> GetForgetPasswordByEmail(
       [FromServices] ICreateEmailForgetPasswordByEmail createEmailForgetPasswordByEmail, [FromQuery] string Correo)
        {
            return Ok(createEmailForgetPasswordByEmail.Execute(Correo));

        }
       

    }
}

