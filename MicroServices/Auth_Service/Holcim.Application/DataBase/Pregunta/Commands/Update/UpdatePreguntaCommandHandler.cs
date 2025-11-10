using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.PreguntaArchivo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Pregunta.Commands.Update
{
    public class UpdatePreguntaCommandHandler : IUpdatePreguntaCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdatePreguntaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }
        public async Task<object> Execute(List<PreguntaArchivo> PreguntaArchivo, Guid? itemid)
        {
            if (PreguntaArchivo != null && PreguntaArchivo.Count > 0)
            {
                foreach (var Listpregunta in PreguntaArchivo)
                {
                    var itempregunta = _dataBaseService.ItemPregunta.Include(x => x.preguntaArchivo).
                             Where(x => x.ItemId == itemid && x.preguntaArchivoId == Listpregunta.IdPreguntaArchivo)
                             .Select(y => y.preguntaArchivo).FirstOrDefault();

                    if (itempregunta != null)
                    {
                        itempregunta.Requerido = Listpregunta.Requerido;
                        itempregunta.Afirmacion = Listpregunta.Afirmacion;
                        itempregunta.Pregunta = Listpregunta.Pregunta;
                        itempregunta.ValoresArchivoId = Listpregunta.ValoresArchivoId;
                        itempregunta.ValoresArchivoJson = JsonConvert.SerializeObject(Listpregunta.ValoresArchivoJson);

                        _dataBaseService.PreguntaArchivo.Update(itempregunta);
                    }
                }
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Preguntas Actulizado Correctamente");
        }


    }
}
