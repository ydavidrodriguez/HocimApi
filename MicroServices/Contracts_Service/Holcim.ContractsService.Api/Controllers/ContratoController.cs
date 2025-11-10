using Holcim.ContractsService.Appilication.Database.Contratos.Command.Create;
using Holcim.ContractsService.Appilication.Database.Contratos.Command.GetById;
using Holcim.ContractsService.Appilication.Database.Contratos.Command.List;
using Holcim.ContractsService.Appilication.Database.Contratos.Command.Update;
using Holcim.ContractsService.Appilication.Database.Contratos.TipoContrato.Commands.List;
using Holcim.ContractsService.Appilication.Exception;
using Holcim.ContractsService.Domain.Models;
using Holcim.ContractsService.Domain.Models.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.ContractsService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ContratoController : ControllerBase
    {
        [HttpGet("GetListContratoAll")]
        public async Task<IActionResult> GetListPscAll(
       [FromServices] IGetListContratoCommandHandler GetListContratoCommandHandler)
        {
            return Ok(await GetListContratoCommandHandler.Execute());

        }

        [HttpGet("GetListTipoContratoAll")]
        public async Task<IActionResult> GetListTipoContratoAll(
       [FromServices] IGetListTipoContratoCommandHandler GetListTipoContratoCommandHandler)
        {
            return Ok(await GetListTipoContratoCommandHandler.Execute());

        }
        [HttpPut("PutUpdateContrato")]
        public async Task<IActionResult> PutUpdatePsc(
        [FromServices] IUpdateContratoCommandHandler UpdateContratoCommandHandler, [FromBody] PutContratoUpdateRequest putContratoUpdateRequest)
        {
            return Ok(await UpdateContratoCommandHandler.Execute(putContratoUpdateRequest));
        }
        [HttpPost("PostCreateContrato")]
        public async Task<IActionResult> PostCreatePsc(
        [FromServices] ICreateContratoCommandHandler CreateContratoCommandHandler, [FromBody] PostCreateContratoRequest createPscRequest)
        {
            return Ok(await CreateContratoCommandHandler.Execute(createPscRequest));

        }

        [HttpGet("GetContratoById")]
        public async Task<IActionResult> GetPscById(
        [FromServices] IGetContratoByIdCommandHandler GetContratoByIdCommandHandler, [FromQuery] Guid IdContrato)
        {
            return Ok(await GetContratoByIdCommandHandler.Execute(IdContrato));
        }

        [HttpPut("PutUpdateStateContratobyId")]
        public async Task<IActionResult> PutUpdateStateContratobyId(
         [FromServices] IUpdateStateContratoCommandHandler updateStateContratoCommandHandler, [FromQuery] Guid Estadoid, [FromQuery] Guid IdContrato  )
        {
            return Ok(await updateStateContratoCommandHandler.Execute(Estadoid, IdContrato));
        }


    }
}
