using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Item;
using Holcim.Domain.Entities.PreguntaArchivo;
using Holcim.Domain.Models.Pregunta;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Pregunta.Commands.Create
{
    public class CreatePreguntaCommandHandler : ICreatePreguntaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreatePreguntaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<object> Execute(List<CrearPregunta> preguntas, Guid? itemId, Guid? idRfx, Guid? ArchivosobreId)
        {

            if (preguntas != null)
            {

                foreach (var pregunta in preguntas)
                {
                    var preguntaArchivo = new PreguntaArchivo
                    {
                        IdPreguntaArchivo = Guid.NewGuid(),
                        Afirmacion = pregunta.Afirmacion,
                        ValoresArchivoJson = JsonConvert.SerializeObject(pregunta.ValoresArchivoJson),
                        ValoresArchivoId = pregunta.ValoresArchivoId.Value,
                        Pregunta = pregunta.Pregunta,
                        ArchivoSobreId = ArchivosobreId,
                        Requerido = pregunta.Requerido.Value

                    };
                    _dataBaseService.PreguntaArchivo.Add(preguntaArchivo);

                    if (itemId != null && itemId != Guid.Empty)
                    {
                        _dataBaseService.ItemPregunta.Add(new ItemPregunta
                        {
                            preguntaArchivoId = preguntaArchivo.IdPreguntaArchivo,
                            ItemId = itemId.Value
                        });
                    }
                    if (ArchivosobreId != null && ArchivosobreId != Guid.Empty)
                    {
                        _dataBaseService.PreguntaSobreRfx.Add(new PreguntaSobreRfx
                        {
                            IdPreguntaSobreRfx = Guid.NewGuid(),
                            RfxId = idRfx.Value,
                            PreguntaArchivoId = preguntaArchivo.IdPreguntaArchivo
                        });
                    }
                }

                return ResponseApiService.Response(StatusCodes.Status201Created, "Preguntas Creadas Correctamente");
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, "No Tiene Preguntas");
            }

        }
    }
}
