using Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Create;
using Holcim.DocumetsService.Application.DataBase.Documentos.Commands.List;
using Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Subasta.Create;
using Holcim.DocumetsService.Application.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.DocumetsService.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DocumentController : ControllerBase
    {
      
        [HttpPost("PostCreateDocument")]
        public async Task<IActionResult> PostCreateDocumentRfx(
        [FromServices] ICreateDocumentRfxCommandHandler CreateDocumentRfxCommandHandler, IFormFile archivo, [FromForm] string jsonData)
        {
            return Ok(await CreateDocumentRfxCommandHandler.Execute(archivo, jsonData));
        }
        [HttpPost("PostCreateDocumentRfxInitial")]
        public async Task<IActionResult> PostCreateDocumentRfxInitial(
        [FromServices] IPostCreateDocumentRfxInitialCommandHandler PostCreateDocumentRfxInitialCommandHandler, IFormFile archivo, [FromForm] string jsonData)
        {
            return Ok(await PostCreateDocumentRfxInitialCommandHandler.Execute(archivo, jsonData));
        }
        [HttpPost("PostCreateDocumentSubastaInitial")]
        public async Task<IActionResult> PostCreateDocumentSubastaInitial(
        [FromServices] IPostInitialDocumentSubastaCommandHandler PostInitialDocumentSubastaCommandHandler, IFormFile file, [FromForm] string jsonData)
        {
           return Ok(await PostInitialDocumentSubastaCommandHandler.Execute(file, jsonData));   
        }

        [HttpGet("ConsultDocument")]
        public async Task<IActionResult> ConsultDocument(
        [FromServices] IConsultDocumentCommandHandler ConsultDocumentCommandHandler, [FromQuery] string? path)
        {
            return Ok(await ConsultDocumentCommandHandler.Execute(path));
        }

    }
}
