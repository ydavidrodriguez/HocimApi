using Holcim.Translate.Application.DataBase.Translate.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Translator.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {

        [HttpGet("GetTranslateText")]
        public async Task<IActionResult> GetTranslateText(
        [FromServices] IPostCreateTranslateCommandHandler PostCreateTranslateCommandHandler, [FromQuery] string Text)
        {
            return Ok(await PostCreateTranslateCommandHandler.Execute(Text));
        }


    }
}
