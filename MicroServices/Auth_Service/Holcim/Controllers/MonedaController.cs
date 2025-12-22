using Holcim.Application.DataBase.Moneda.Commands.Create;
using Holcim.Application.DataBase.Moneda.Commands.List;
using Holcim.Application.DataBase.Moneda.Commands.Update;
using Holcim.Application.Exception;
using Holcim.Domain.Models.Moneda;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class MonedaController : ControllerBase
    {

        [HttpGet("GetListMonedaAll")]
        public async Task<IActionResult> GetListMonedaAll(
        [FromServices] IListMonedaCommandHandler ListMonedaCommandHandler, [FromQuery] string? Nombre, [FromQuery] string? codigo)
        {
            return Ok(await ListMonedaCommandHandler.Execute(Nombre, codigo));
        }

        [HttpPost("PostCreateMoneda")]
        public async Task<IActionResult> PostCreateMoneda(
        [FromServices] ICreateMonedaCommandHandler CreateRegionCommandHandler, [FromBody] List<CreateMonedaRequest> createMonedaRequest)
        {
            return Ok(await CreateRegionCommandHandler.Execute(createMonedaRequest));
        }
        [HttpPut("PutUpdateMoneda")]
        public async Task<IActionResult> PutUpdateMoneda(
        [FromServices] IUpdateMonedaCommandHandler updateMonedaCommandHandler, [FromBody] UpdateMonedaRequest UpdateMonedaRequest)
        {
            return Ok(await updateMonedaCommandHandler.Execute(UpdateMonedaRequest));
        }
        [HttpGet("GetListMonedaById")]
        public async Task<IActionResult> GetListMonedaById(
        [FromServices] IListMonedaByIdCommandHandler listMonedaByIdCommandHandler, [FromQuery] Guid IdMoneda)
        {
            return Ok(await listMonedaByIdCommandHandler.Execute(IdMoneda));
        }

    }
}
