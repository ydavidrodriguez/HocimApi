using Holcim.Application.DataBase.Idioma.Commands.List;
using Holcim.Application.Exception;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class IdiomaController : ControllerBase
    {

        [HttpGet("GetListIdiomaAll")]
        public async Task<IActionResult> GetListIdiomaAll(
          [FromServices] IListIdiomaCommandHandler ListIdiomaCommandHandler)
        {
            return Ok(await ListIdiomaCommandHandler.Execute());
        }
    }
}
