using Holcim.Application.DataBase.Pais.Commands.List;
using Holcim.Application.DataBase.ZonaHoraria.Commands.List;
using Holcim.Application.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ZonaHorariaController : ControllerBase
    {
      
        [HttpGet("GetListZonaHorariaAll")]
        public async Task<IActionResult> GetListZonaHorariaAll(
           [FromServices] IGetZonaHorariaCommandHandler GetZonaHorariaCommandHandler)
        {
            return Ok(await GetZonaHorariaCommandHandler.Execute());

        }
    }
}
