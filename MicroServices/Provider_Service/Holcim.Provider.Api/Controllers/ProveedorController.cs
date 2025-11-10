using Holcim.Provider.Application.Database.Proveedor.Commands.Create;
using Holcim.Provider.Application.Database.Proveedor.Commands.List;
using Holcim.Provider.Application.Database.Proveedor.Commands.Update;
using Holcim.Provider.Application.Exception;
using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Domain.Models;
using Holcim.Provider.Domain.Models.Proveedor;
using Holcim.Provider.Domain.Models.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Provider.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ProveedorController : ControllerBase
    {

        [HttpGet("GetListQuestionProvider")]
        public IActionResult GetListQuestionProvider(
        [FromServices] IGetListQuestionProviderCommandHandler GetListQuestionProvider, [FromQuery] Guid IdRfx)
        {
            return Ok(GetListQuestionProvider.Execute(IdRfx));
        }

        [HttpGet("GetListRfxProvider")]
        public IActionResult GetListRfxProvider(
        [FromServices] IGetListRfxProviderCommandHandler GetListRfxProviderCommandHandler, [FromQuery] Guid UsuarioId)
        {
            return Ok(GetListRfxProviderCommandHandler.Execute(UsuarioId));
        }

        [HttpPost("CreateUserProviderByProvider")]
        public IActionResult CreateUserProviderByProvider(
        [FromServices] ICreateUserProviderByProviderCommandHandler CreateUserProviderByProviderCommandHandler, [FromBody] CreateUserProviderRequest CreateUserProviderRequest)
        {
            return Ok(CreateUserProviderByProviderCommandHandler.Execute(CreateUserProviderRequest));
        }

        [HttpGet("GetListUserProvider")]
        public IActionResult CreateUserProviderByProvider(
        [FromServices] IGetListUserProviderCommandHandler getListUserProviderCommandHandler, [FromQuery] Guid IdProveedor)
        {
            return Ok(getListUserProviderCommandHandler.Execute(IdProveedor));
        }
        [HttpPost("UpdateUserProviderByProvider")]
        public IActionResult UpdateUserProviderByProvider(
        [FromServices] IUpdateUserProviderByProvider UpdateUserProviderByProvider, [FromBody] PutUsuarioUpdateRequest putUsuarioUpdateRequest)
        {
            return Ok(UpdateUserProviderByProvider.Execute(putUsuarioUpdateRequest));
        }
        [HttpGet("GetPorcentResponseProviderByRfx")]
        public IActionResult GetPorcentResponseProviderByRfx(
        [FromServices] IGetPorcentResponseProviderByRfx GetPorcentResponseProviderByRfx, [FromQuery] Guid Idrfx)
        {
            return Ok(GetPorcentResponseProviderByRfx.Execute(Idrfx));
        }

        [HttpPost("CreateProviderBulk")]
        public IActionResult CreateProviderBulk(
        [FromServices] ICreateProviderBulkCommandHandler CreateProviderBulkCommandHandler, [FromBody] List<CreateUserBulkRequest> createUserBulkRequest)
        {
            return Ok(CreateProviderBulkCommandHandler.Execute(createUserBulkRequest));
        }

        [HttpGet("GetListUactionProvider")]
        public IActionResult GetListUactionProvider(
        [FromServices] IGetListAuctionProviderCommandHandler GetListAuctionProviderCommandHandler, [FromQuery] Guid IdUsuario)
        {
            return Ok(GetListAuctionProviderCommandHandler.Execute(IdUsuario));
        }

        [HttpGet("GetListResponseQuestionProvider")]
        public async Task<IActionResult> GetListUactionProvider(
        [FromServices] IGetListResponseQuestionProviderCommandHandler GetListResponseQuestionProviderCommandHandler, 
        [FromQuery] Guid IdProveedor, [FromQuery] Guid IdRfx)
        {
            return Ok( await GetListResponseQuestionProviderCommandHandler.Execute(IdProveedor, IdRfx)); 
        }
        [HttpPut("PutUpdateQuestionProvider")]
        public async Task<IActionResult> PutUpdateQuestionProvider(
          [FromServices] IUpdateResponseQuestionProviderCommandHandler UpdateResponseQuestionProviderCommandHandler,
          [FromBody] List<RespuestaPregunta> respuestaPreguntas)
        {
            return Ok(await UpdateResponseQuestionProviderCommandHandler.Execute(respuestaPreguntas));
        }



    }
}
