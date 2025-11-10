using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.Update
{
    public interface IPutUpdatePathRfxCommandHandler
    {
        Task<object> Execute(UpdatePathRfxRequest UpdatePathRfxRequest);
    }
}
