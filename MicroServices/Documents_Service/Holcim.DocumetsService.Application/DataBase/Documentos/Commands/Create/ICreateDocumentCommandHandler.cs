using Microsoft.AspNetCore.Http;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Create
{
    public interface ICreateDocumentCommandHandler
    {
        Task<object> Execute(IFormFile formFile);
    }
}
