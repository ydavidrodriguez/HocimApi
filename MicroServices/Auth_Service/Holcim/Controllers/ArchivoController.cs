using Holcim.Application.DataBase.Archivo.Commands.List;
using Holcim.Application.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ArchivoController : ControllerBase
    {
        [HttpGet("GetListTipoRfxById")]
        public async Task<IActionResult> GetListTipoRfxById(
        [FromServices] IListArchivosByTypeArchivoCommand listArchivosByTypeArchivoCommandHandler, [FromQuery] Guid IdTipoRfx)
        {
            return Ok(await listArchivosByTypeArchivoCommandHandler.Execute(IdTipoRfx));
        }

        [HttpGet("GetListValoresArchivo")]
        public async Task<IActionResult> GetListValoresArchivo(
        [FromServices] IListValoresArchivoCommand listValoresArchivoCommand)
        {
            return Ok(await listValoresArchivoCommand.Execute());
        }

    }
}
