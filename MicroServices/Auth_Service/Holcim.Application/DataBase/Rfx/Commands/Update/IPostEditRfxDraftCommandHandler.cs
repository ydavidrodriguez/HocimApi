using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.Update
{
    public interface IPostEditRfxDraftCommandHandler
    {
        Task<object> Execute(UpdateRfxRequestDraft updateRfxRequestDraft);
    }
}
