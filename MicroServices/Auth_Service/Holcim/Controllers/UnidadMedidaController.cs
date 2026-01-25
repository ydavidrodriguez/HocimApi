using Holcim.Application.DataBase.UnidadMedida.Commands.Create;
using Holcim.Application.DataBase.UnidadMedida.Commands.GetById;
using Holcim.Application.DataBase.UnidadMedida.Commands.List;
using Holcim.Application.DataBase.UnidadMedida.Commands.Update;
using Holcim.Application.Exception;
using Holcim.Domain.Models.UnidadMedida;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class UnidadMedidaController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("GetListUnidadMedidaAll")]
        public async Task<IActionResult> GetListUnidadMedidaAll(
         [FromServices] IListUnidadMedidaCommandHandler IListUnidadMedidaCommandHandler , [FromQuery] string? UdmCode)
        {
            return Ok(await IListUnidadMedidaCommandHandler.Execute(UdmCode));

        }

        [HttpPut("PutUpdateUnidadMedida")]
        public async Task<IActionResult> PutUpdateUnidadMedida(
        [FromServices] IUpdateUnidadMedidaCommandHandler UpdateUnidadMedidaCommandHandler, [FromBody] UpdateUnidadMedidaRequest updateUnidadMedidaRequest)
        {
            return Ok(await UpdateUnidadMedidaCommandHandler.Execute(updateUnidadMedidaRequest));
        }

        [HttpPost("PostCreateUnidadMedida")]
        public async Task<IActionResult> PostCreateUnidadMedida(
        [FromServices] ICreateUnidadMedidaCommandHandler CreateUnidadMedidaCommandHandler, [FromBody] List<CreateUnidadMedidaRequest> createUnidadMedidaRequest)
        {
            return Ok(await CreateUnidadMedidaCommandHandler.Execute(createUnidadMedidaRequest));
        }

        [HttpGet("GetUnidadMedidaById")]
        public async Task<IActionResult> GetUnidadMedidaById(
        [FromServices] IUnidadMedidaGetByIdCommandHandler UnidadMedidaGetByIdCommandHandler, [FromQuery] Guid IdUnidad)
        {
            return Ok(await UnidadMedidaGetByIdCommandHandler.Execute(IdUnidad));
        }

    }
}
