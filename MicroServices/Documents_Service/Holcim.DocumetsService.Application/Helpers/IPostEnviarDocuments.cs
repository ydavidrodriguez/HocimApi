using Microsoft.AspNetCore.Http;

namespace Holcim.DocumetsService.Application.Helpers
{
    public interface IPostEnviarDocuments
    {
        Task<object> PostExecuteDocuments(IFormFile formFile, string Path);
    }
}
