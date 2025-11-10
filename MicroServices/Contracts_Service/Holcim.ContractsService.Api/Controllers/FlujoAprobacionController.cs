using Holcim.ContractsService.Appilication.Database.FlujoAprobacion.Command.Create;
using Holcim.ContractsService.Appilication.Exception;
using Holcim.ContractsService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.ContractsService.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class FlujoAprobacionController : ControllerBase
    {
        [HttpPost("PostCreateFlujoAprobacion")]
        public async Task<IActionResult> PostCreateFlujoAprobacion(
        [FromServices] ICreateFlujoAprobacionCommandHandler CreateFlujoAprobacionCommandHandler,
        [FromBody] CreateFlujoAprobacionRequest createFlujoAprobacionRequest)
        {
            return Ok(await CreateFlujoAprobacionCommandHandler.Execute(createFlujoAprobacionRequest));

        }
    }
}
