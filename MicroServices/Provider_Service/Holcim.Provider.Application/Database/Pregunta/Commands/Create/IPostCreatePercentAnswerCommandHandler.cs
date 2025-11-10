using Holcim.Provider.Domain.Models.Pregunta;

namespace Holcim.Provider.Application.Database.Pregunta.Commands.Create
{
    public interface IPostCreatePercentAnswerCommandHandler
    {
        Task<object> Execute(CreateQuestionPercent createQuestionPercent);
    }
}
