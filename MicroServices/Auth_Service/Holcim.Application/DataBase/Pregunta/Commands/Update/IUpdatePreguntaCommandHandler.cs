using Holcim.Domain.Entities.PreguntaArchivo;

namespace Holcim.Application.DataBase.Pregunta.Commands.Update
{
    public interface IUpdatePreguntaCommandHandler
    {
        Task<object> Execute(List<PreguntaArchivo> PreguntaArchivo, Guid? itemid);
    }
}
