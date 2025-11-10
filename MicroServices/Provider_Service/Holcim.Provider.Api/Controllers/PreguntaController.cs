using Holcim.Provider.Application.Database.Pregunta.Commands.Create;
using Holcim.Provider.Application.Database.Pregunta.Commands.List;
using Holcim.Provider.Application.Database.Proveedor.Commands.Create;
using Holcim.Provider.Application.Exception;
using Holcim.Provider.Domain.Models;
using Holcim.Provider.Domain.Models.Pregunta;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Provider.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PreguntaController : ControllerBase
    {
        [HttpPost("PostResponseCreateQuestionProvider")]
        public async Task<IActionResult> PostResponseCreateQuestionProvider(
        [FromServices] IPostResponseCreateQuestionProvider PostResponseCreateQuestionProvider, [FromBody] List<RespuestaPreguntaRequest> respuestaPregunta)
        {
            return Ok(await PostResponseCreateQuestionProvider.Execute(respuestaPregunta));
        }
        [HttpGet("GetQuestionReplyRfxList")]
        public async Task<IActionResult> GetQuestionReplyRfxList(
        [FromServices] IGetListQuestionReplyRfxListCommandHandler GetListQuestionReplyRfxList)
        {
            return Ok(await GetListQuestionReplyRfxList.Execute());
        }
        [HttpGet("GetQuestionReplyRfxListByRfxid")]
        public async Task<IActionResult> GetQuestionReplyRfxListByRfxid(
        [FromServices] IGetListQuestionReplyRfxListByRfxidCommandHandler GetListQuestionReplyRfxListByRfxidCommandHandler, [FromQuery] Guid IdRfx)
        {
            return Ok(await GetListQuestionReplyRfxListByRfxidCommandHandler.Execute(IdRfx));
        }
        [HttpPost("GetQuestionReplyRfxListByProveedorId")]
        public async Task<IActionResult> GetQuestionReplyRfxListByProveedorId(
        [FromServices] IGetQuestionReplyRfxListByProveedorIdCommandHandler getQuestionReplyRfxListByProveedorIdCommandHandler, [FromBody] GetQuestionsProviderByRfxidRequest getQuestionsProviderByRfxidRequest)
        {
            return Ok(await getQuestionReplyRfxListByProveedorIdCommandHandler.Execute(getQuestionsProviderByRfxidRequest));
        }
        [HttpGet("GetListQuestionResponseProviderRfx")]
        public async Task<IActionResult> GetListQuestionResponseProviderRfx(
        [FromServices] IGetListQuestionResponseProviderRfxCommandHandler getListQuestionResponseProviderRfxCommandHandler, [FromQuery] Guid IdRFX)
        {
            return Ok(await getListQuestionResponseProviderRfxCommandHandler.Execute(IdRFX));
        }
        [HttpPost("PostCreatePercentAnswer")]
        public async Task<IActionResult> PostCreatePercentAnswer(
        [FromServices] IPostCreatePercentAnswerCommandHandler postCreatePercentAnswerCommandHandler, [FromBody] CreateQuestionPercent createQuestionPercent)
        {
            return Ok(await postCreatePercentAnswerCommandHandler.Execute(createQuestionPercent));
        }
        [HttpGet("GetListQuestionProviderList")]
        public async Task<IActionResult> GetListQuestionProviderList(
        [FromServices] IGetListQuestionReplyRfxListCommandHandler GetListQuestionReplyRfxList, 
        [FromQuery]Guid IdProveedor,
        [FromQuery]Guid IdRfx )
        {
            return Ok(await GetListQuestionReplyRfxList.Execute());
        }

    }
}
