using Holcim.Application.DataBase.Cargo.Commands.List;
using Holcim.Application.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class CargoController : ControllerBase
    {
        [HttpGet("GetListCargoAll")]
        public async Task<IActionResult> GetListCargoAll(
          [FromServices] IListCargoCommandHandler ListCargoCommandHandler)
        {
            return Ok(await ListCargoCommandHandler.Execute());
        }
    }
}
