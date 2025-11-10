using Holcim.Domain.Entities.PreguntaArchivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.Application.DataBase.Pregunta.Commands.Delete
{
    public interface IDeletePreguntaCommandHandler
    {
        Task<object> Execute(List<PreguntaArchivo> preguntas);
    }
}
