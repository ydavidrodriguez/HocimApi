using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.Update
{
    public interface IUpdateRfxCommandHandler
    {
        Task<object> Execute(UpdateRfxRequest updateRfxRequest);
    }
}
