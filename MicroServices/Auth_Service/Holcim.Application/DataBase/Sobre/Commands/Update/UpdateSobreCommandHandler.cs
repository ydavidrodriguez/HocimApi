using Holcim.Application.Feature;
using Holcim.Domain.Entities.Archivos;
using Holcim.Domain.Entities.PreguntaArchivo;
using Holcim.Domain.Models.Archivo;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Sobre.Commands.Update
{
    public class UpdateSobreCommandHandler : IUpdateSobreCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;

        public UpdateSobreCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<object> Execute(ArchivoSobrePreguntas ArchivoSobre)
        {
            var sobreEntity = _dataBaseService.ArchivoSobre
                .FirstOrDefault(x => x.IdArchivo == ArchivoSobre.ArchivoSobre.IdArchivo);

            if (sobreEntity == null)
            {
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Sobre no encontrado");
            }

            // ✅ Actualizar los campos del sobre
            sobreEntity.NombreArchivo = ArchivoSobre.ArchivoSobre.NombreArchivo;
            sobreEntity.TipoArchivoId = ArchivoSobre.ArchivoSobre.TipoArchivoId;
            sobreEntity.FechaActualizacion = DateTime.Now;

            _dataBaseService.ArchivoSobre.Update(sobreEntity);

            // ✅ Procesar preguntas (nuevas o modificadas)
            foreach (
                var preguntaArchivoSobre in ArchivoSobre.CrearPregunta ?? new List<PreguntaDto>())
            {
                var idPregunta = preguntaArchivoSobre.IdPreguntaArchivo;

                var preguntaExistente = idPregunta != null
                    ? _dataBaseService.PreguntaArchivo.FirstOrDefault(p => p.IdPreguntaArchivo == idPregunta)
                    : null;

                if (preguntaExistente == null)
                {
                    // ➕ Agregar nueva pregunta
                    var nuevaPregunta = new PreguntaArchivo
                    {
                        IdPreguntaArchivo = Guid.NewGuid(),
                        ArchivoSobreId = sobreEntity.IdArchivo,
                        Pregunta = preguntaArchivoSobre.Pregunta,
                        Detalle = preguntaArchivoSobre.Detalle,
                        ValoresArchivoId = preguntaArchivoSobre.TipoRespuesta,
                        Requerido = preguntaArchivoSobre.Requerido,
                        ValoresArchivoJson = preguntaArchivoSobre.Opciones != null && preguntaArchivoSobre.Opciones.Any()
                            ? JsonConvert.SerializeObject(preguntaArchivoSobre.Opciones)
                            : null,
                    };

                    _dataBaseService.PreguntaArchivo.Add(nuevaPregunta);
                }
                else
                {
                    // 🔄 Actualizar la existente
                    preguntaExistente.Pregunta = preguntaArchivoSobre.Pregunta;
                    preguntaExistente.Detalle = preguntaArchivoSobre.Detalle;
                    preguntaExistente.ValoresArchivoId = preguntaArchivoSobre.TipoRespuesta;
                    preguntaExistente.Requerido = preguntaArchivoSobre.Requerido;
                    preguntaExistente.ValoresArchivoJson = preguntaArchivoSobre.Opciones != null && preguntaArchivoSobre.Opciones.Any()
                        ? JsonConvert.SerializeObject(preguntaArchivoSobre.Opciones)
                        : null;

                    // No necesitas llamar a `.Update()` si el contexto ya está rastreando la entidad.
                }
            }
            return ResponseApiService.Response(StatusCodes.Status201Created, "Sobre actualizado correctamente");
        }
    }


}
