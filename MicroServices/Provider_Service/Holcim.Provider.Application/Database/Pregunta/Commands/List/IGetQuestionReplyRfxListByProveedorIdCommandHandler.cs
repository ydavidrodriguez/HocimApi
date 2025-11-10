using Holcim.Provider.Domain.Models;

namespace Holcim.Provider.Application.Database.Pregunta.Commands.List
{
    public interface IGetQuestionReplyRfxListByProveedorIdCommandHandler
    {
        Task<object> Execute(GetQuestionsProviderByRfxidRequest getQuestionsProviderByRfxidRequest);
    }
}
