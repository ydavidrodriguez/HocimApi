using Microsoft.AspNetCore.Http;

namespace Holcim.FileSend.Application.DataBase.FileRfx.Commands.Create
{
    public interface ICreateFileRfxCommandHandler
    {
        Task<object> Execute(List<IFormFile> Files);
    }
}
