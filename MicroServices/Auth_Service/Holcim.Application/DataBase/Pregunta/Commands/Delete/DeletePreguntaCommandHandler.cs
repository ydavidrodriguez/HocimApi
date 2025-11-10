using Holcim.Application.Feature;
using Holcim.Domain.Entities.PreguntaArchivo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.Application.DataBase.Pregunta.Commands.Delete
{
    public class DeletePreguntaCommandHandler : IDeletePreguntaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        public DeletePreguntaCommandHandler(IDataBaseService dataBaseService)
        {
                _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(List<PreguntaArchivo> preguntas)
        {
            if (preguntas != null && preguntas.Count > 0)
            {
                foreach (var pregunta in preguntas)
                {
                    // Eliminar registros relacionados en PreguntaSobreRfx
                    var preguntasSobreRfx = _dataBaseService.PreguntaArchivo
                        .Where(x => x.IdPreguntaArchivo == pregunta.IdPreguntaArchivo)
                        .ToList();
                    // Eliminar la pregunta
                    _dataBaseService.PreguntaArchivo.Remove(pregunta);
                }
                
            }
            return ResponseApiService.Response(StatusCodes.Status201Created, "Preguntas Eliminadas Correctamente");
        }
    }
}
