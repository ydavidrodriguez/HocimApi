using Holcim.Application.DataBase.Estado.Commads.List;
using Holcim.Application.DataBase.Estado.TipoEstado.List;
using Holcim.Application.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class EstadoController : Controller
    {

        [HttpGet("GetListEstadoAll")]
        public async Task<IActionResult> GetListEstadoAll(
         [FromServices] IListEstadoCommandHandler ListEstadoCommandHandler, [FromQuery] string? Nombre, [FromQuery] string? TipoEstado, [FromQuery] Guid? EstadoId)
        {
            return Ok(await ListEstadoCommandHandler.Execute(Nombre,TipoEstado,EstadoId));
        }

        [HttpGet("GetListEstadoByType")]
        public async Task<IActionResult> GetListEstadoByType(
       [FromServices] IListEstadoByTypeCommandHandler listEstadoByTypeCommandHandler, [FromQuery] Guid IdTipoEstado)
        {
            return Ok(await listEstadoByTypeCommandHandler.Execute(IdTipoEstado));
        }

        [HttpGet("GetListTipoEstado")]
        public async Task<IActionResult> GetListTipoEstado(
        [FromServices] IListTipoEstadoCommandHandler ListTipoEstadoCommandHandler)
        {
            return Ok(await ListTipoEstadoCommandHandler.Execute());
        }


    }
}
