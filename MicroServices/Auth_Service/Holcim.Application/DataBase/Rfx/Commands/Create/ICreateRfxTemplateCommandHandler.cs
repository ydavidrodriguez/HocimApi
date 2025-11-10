using Holcim.Domain.Models.Rfx;

namespace Holcim.Application.DataBase.Rfx.Commands.Create
{
    public interface ICreateRfxTemplateCommandHandler
    {
        Task<object> Execute(CreateRfxRequestDraft createRfxRequestDraft);

    }
}
