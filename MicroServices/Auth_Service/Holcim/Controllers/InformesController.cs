using Holcim.Application.DataBase.Informe.Commands.Create;
using Holcim.Application.DataBase.Informe.Commands.GetById;
using Holcim.Application.DataBase.Informe.Commands.List;
using Holcim.Application.DataBase.Informe.Commands.Update;
using Holcim.Application.Exception;
using Holcim.Domain.Models.Informes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class InformesController : ControllerBase
    {

        [HttpGet("GetListInformesAll")]
        public async Task<IActionResult> GetListInformesAll(
       [FromServices] IListInformesCommandHandler IListInformesCommandHandler, [FromQuery] string? Nombre)
        {
            return Ok(await IListInformesCommandHandler.Execute(Nombre));

        }

        [HttpPut("PutUpdateInformes")]
        public async Task<IActionResult> PutUpdateInformes(
        [FromServices] IUpdateInformesCommandHandler updateInformesCommandHandler, [FromBody] UpdateInformesRequest updateInformesRequest)
        {
            return Ok(await updateInformesCommandHandler.Execute(updateInformesRequest));
        }

        [HttpPost("PostCreateInformes")]
        public async Task<IActionResult> PostCreateInformes(
        [FromServices] ICreateInformesCommandHandler CreateInformesCommandHandler, [FromBody] CreateInformesRequest CreateInformesRequest)
        {
            return Ok(await CreateInformesCommandHandler.Execute(CreateInformesRequest));

        }

        [HttpGet("GetUnidadInformesById")]
        public async Task<IActionResult> GetUnidadInformesById(
        [FromServices] IInformesGetByIdCommandHandler InformesGetByIdCommandHandler, [FromQuery] Guid IdInforme)
        {
            return Ok(await InformesGetByIdCommandHandler.Execute(IdInforme));
        }

    }
}
