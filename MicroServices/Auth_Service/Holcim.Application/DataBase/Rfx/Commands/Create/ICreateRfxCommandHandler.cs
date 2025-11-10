using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.Create
{
    public interface ICreateRfxCommandHandler
    {
        Task<object> Execute(CreateRfxRequest createRfxRequest);
    }
}
