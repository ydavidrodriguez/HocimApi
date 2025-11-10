using Microsoft.AspNetCore.Http;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Create
{
    public interface IPostCreateDocumentRfxInitialCommandHandler
    {
        Task<object> Execute(IFormFile formFile, string jsondata);
    }
}
