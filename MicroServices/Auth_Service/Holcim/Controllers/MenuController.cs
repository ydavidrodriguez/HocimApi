using Holcim.Application.DataBase.Menu.Commands.List;
using Holcim.Application.DataBase.Usuario.Commands.List;
using Holcim.Application.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class MenuController : ControllerBase
    {
        [HttpGet("GetUsuarioMenuByEmail")]
        public async Task<IActionResult> GetUsuarioMenuByEmail(
           [FromServices] IGetUsuarioMenuByEmail GetUsuarioMenuByEmail, [FromQuery] Guid IdUsuario)
        {
            return Ok(await GetUsuarioMenuByEmail.Execute(IdUsuario));
        }

        [HttpGet("GetMenuById")]
        public async Task<IActionResult> GetMenuById(
           [FromServices] IGetMenuByIdCommandHandler getMenuByIdCommandHandler, [FromQuery] Guid IdUsuario)
        {
            return Ok(await getMenuByIdCommandHandler.Execute(IdUsuario));
        }

    }
}
