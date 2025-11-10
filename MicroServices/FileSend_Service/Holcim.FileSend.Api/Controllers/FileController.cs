using Holcim.FileSend.Application.DataBase.FileRfx.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.FileSend.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FileController : ControllerBase
    {
        [HttpPost("PostUpdateFileRfx")]
        public async Task<IActionResult> PostUpdateFileRfx(
        [FromServices] ICreateFileRfxCommandHandler CreateFileRfxCommandHandler, [FromForm] List<IFormFile> Files)
        {
            return Ok(await CreateFileRfxCommandHandler.Execute(Files));

        }
    }
}
