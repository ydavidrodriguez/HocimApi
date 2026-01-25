using Holcim.Application.External.Traduccion;
using Holcim.Domain.Models;
using Holcim.Domain.Models.Idioma;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.External.Traduccion
{
    public class GetTraduccionService : IGetTraduccionService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTraduccionService(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Execute(string texto)
        {

            var client = _httpClientFactory.CreateClient("ApiGatewayService");
            var lang = _httpContextAccessor.HttpContext?.Items["lang"] as string ?? "es";
            var gettraaducion = await client.GetAsync("/trasnlator/api/Translate/GetTranslateText?Text=" + texto + "&lang=" + lang);
            if (gettraaducion.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return gettraaducion.RequestMessage?.ToString() ?? string.Empty;
            }
            var traduccion = await gettraaducion.Content.ReadAsStringAsync();
            BaseResponseModel? IdiomasaResult = JsonConvert.DeserializeObject<BaseResponseModel>(traduccion);
            if (IdiomasaResult?.Data == null)
            {
                return string.Empty;
            }

            List<TraduccionResponse> IdiomaRequest = IdiomasaResult.Data.ToObject<List<TraduccionResponse>>() ?? new List<TraduccionResponse>();
            List<IdiomaResponse> idiomanew = new List<IdiomaResponse>();

            foreach (var idioma in IdiomaRequest)
            {
                IdiomaResponse idiomaresponse = new IdiomaResponse();
                idiomanew.Add(new IdiomaResponse
                {
                    Idioma = idioma.idiomaDestino,
                    Valor = idioma.textoTraducido
                });
            }
            string jsoidioma = JsonConvert.SerializeObject(idiomanew);

            return jsoidioma;
        }
        public string GetTranslatedName(string jsonNombre, string key)
        {
            var idioma = JsonConvert.DeserializeObject<List<IdiomaResponse>>(jsonNombre);
            return idioma?.FirstOrDefault(x => x.Idioma == key)?.Valor ?? string.Empty;
        }
    }
}
