using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.Update
{
    public class UpdateResponseQuestionProviderCommandHandler : IUpdateResponseQuestionProviderCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;

        public UpdateResponseQuestionProviderCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;

        }
        public async Task<object> Execute(List<RespuestaPregunta> postRespuestaPregunta)
        {

            foreach (var itempregunta in postRespuestaPregunta)
            {

                RespuestaPregunta respuestaPreguntaitem = _dataBaseService.RespuestaPregunta.Where(x => x.IdRespuestaPregunta
                == itempregunta.IdRespuestaPregunta)
                    .FirstOrDefault();

                if (respuestaPreguntaitem != null)
                {
                    RespuestaPregunta respuestaPregunta = new RespuestaPregunta();
                    respuestaPregunta.UrlArchivo = itempregunta.UrlArchivo;
                    respuestaPregunta.Respuesta = itempregunta.Respuesta;

                    _dataBaseService.RespuestaPregunta.Update(respuestaPregunta);
                }
            }

            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status201Created, postRespuestaPregunta);
        }

    }
}
