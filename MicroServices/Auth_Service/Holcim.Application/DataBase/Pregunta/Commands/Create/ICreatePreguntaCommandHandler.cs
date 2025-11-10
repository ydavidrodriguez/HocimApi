using Holcim.Domain.Models.Menu;
using Holcim.Domain.Models.Pregunta;

namespace Holcim.Application.DataBase.Pregunta.Commands.Create
{
    public interface ICreatePreguntaCommandHandler
    {
        Task<object> Execute(List<CrearPregunta> preguntas, Guid? itemId, Guid? idRfx, Guid? ArchivosobreId);
    }
}
