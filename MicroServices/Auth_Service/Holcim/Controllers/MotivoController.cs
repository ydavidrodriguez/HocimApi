using Holcim.Application.DataBase.Motivo.Commands.List;
using Holcim.Application.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class MotivoController : ControllerBase
    {
        [HttpGet("GetListMotivo")]
        public async Task<IActionResult> GetListMotivo(
        [FromServices] IListMotivoCommandHandler ListMotivoCommandHandler)
        {
            return Ok(await ListMotivoCommandHandler.Execute());
        }
    }
}
