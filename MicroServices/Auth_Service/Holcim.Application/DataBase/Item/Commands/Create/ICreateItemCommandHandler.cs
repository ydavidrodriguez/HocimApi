using Holcim.Domain.Models.Item;
using Holcim.Domain.Models.Pregunta;

namespace Holcim.Application.DataBase.Item.Commands.Create
{
    public interface ICreateItemCommandHandler
    {
        Task<object> Execute(List<CreateItemRequest> items, Guid? rfxId, List<CrearPregunta>? preguntas);
    }
}
