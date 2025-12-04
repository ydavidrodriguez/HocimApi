using Holcim.Application.DataBase.InformesRol.Create;
using Holcim.Application.DataBase.UnidadMedida.Commands.Create;
using Holcim.Application.DataBase.UnidadMedida.Commands.GetById;
using Holcim.Application.DataBase.UnidadMedida.Commands.List;
using Holcim.Application.DataBase.UnidadMedida.Commands.Update;
using Holcim.Application.Exception;
using Holcim.Domain.Models.Informes;
using Holcim.Domain.Models.UnidadMedida;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class InformesRolController : ControllerBase
    {

        [HttpGet("GetListInformesRolAll")]
        public async Task<IActionResult> GetListInformesAll(
        [FromServices] IListUnidadMedidaCommandHandler IListUnidadMedidaCommandHandler, [FromQuery] string? UdmCode)
        {
            return Ok(await IListUnidadMedidaCommandHandler.Execute(UdmCode));

        }

        [HttpPut("PutUpdateInformesRol")]
        public async Task<IActionResult> PutUpdateInformes(
        [FromServices] IUpdateUnidadMedidaCommandHandler UpdateUnidadMedidaCommandHandler, [FromBody] UpdateUnidadMedidaRequest updateUnidadMedidaRequest)
        {
            return Ok(await UpdateUnidadMedidaCommandHandler.Execute(updateUnidadMedidaRequest));
        }

        [HttpPost("PostCreateInformesRol")]
        public async Task<IActionResult> PostCreateInformes(
        [FromServices] ICreateInformesRolCommandHandler CreateInformesRolCommandHandler, [FromBody] List<CreateInformesRolRequest> createInformesRolRequest)
        {
            return Ok(await CreateInformesRolCommandHandler.Execute(createInformesRolRequest));

        }

        [HttpGet("GetUnidadInformesRolById")]
        public async Task<IActionResult> GetUnidadInformesById(
        [FromServices] IUnidadMedidaGetByIdCommandHandler UnidadMedidaGetByIdCommandHandler, [FromQuery] Guid IdUnidad)
        {
            return Ok(await UnidadMedidaGetByIdCommandHandler.Execute(IdUnidad));
        }

    }
}
