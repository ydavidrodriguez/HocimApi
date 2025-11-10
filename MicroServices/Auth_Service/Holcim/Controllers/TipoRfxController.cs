using Holcim.Application.DataBase.Cargo.Commands.List;
using Holcim.Application.DataBase.Moneda.Commands.Create;
using Holcim.Application.DataBase.Moneda.Commands.List;
using Holcim.Application.DataBase.Moneda.Commands.Update;
using Holcim.Application.DataBase.TipoRfx.Commands.Create;
using Holcim.Application.DataBase.TipoRfx.Commands.List;
using Holcim.Application.Exception;
using Holcim.Domain.Models.Moneda;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class TipoRfxController : ControllerBase
    {
        [HttpGet("GetListTipoRfxAll")]
        public async Task<IActionResult> GetListTipoRfxAll(
        [FromServices] IListTipoRfxCommandHandler ListMonedaCommandHandler)
        {
            return Ok(await ListMonedaCommandHandler.Execute());
        }

        [HttpPost("PostCreateTipoRfx")]
        public async Task<IActionResult> PostCreateTipoRfx(
        [FromServices] ICreateTipoRfxCommandHandler CreateTipoRfxCommandHandler, [FromBody] CreateTipoRfxRequest createTipoRfxRequest)
        {
            return Ok(await CreateTipoRfxCommandHandler.Execute(createTipoRfxRequest));
        }
        [HttpGet("GetListTipoRfxById")]
        public async Task<IActionResult> GetListTipoRfxById(
        [FromServices] IListMonedaByIdCommandHandler listMonedaByIdCommandHandler, [FromQuery] Guid IdMoneda)
        {
            return Ok(await listMonedaByIdCommandHandler.Execute(IdMoneda));
        }


    }
}
