using Microsoft.AspNetCore.Http;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Create
{
    public interface ICreateDocumentRfxCommandHandler
    {
        Task<object> Execute(IFormFile formFile, string jsondata);
    }
}
