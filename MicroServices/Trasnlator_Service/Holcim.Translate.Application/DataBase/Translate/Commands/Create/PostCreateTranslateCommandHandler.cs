using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;
using Amazon.Translate;
using Amazon.Translate.Model;
using Holcim.Translate.Application.Feature;
using Holcim.Translate.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Holcim.Translate.Application.DataBase.Translate.Commands.Create
{
    public class PostCreateTranslateCommandHandler : IPostCreateTranslateCommandHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostCreateTranslateCommandHandler(IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<object> Execute(string textoOring)
        {

            var awsCredentials = new BasicAWSCredentials(
            _configuration["AWS:awsAccessKeyId"], _configuration["AWS:awsSecretAccessKey"]);

            Console.WriteLine("AWS Access Key: " + awsCredentials.GetCredentials().AccessKey);

            var awsClient = new AmazonTranslateClient(awsCredentials, RegionEndpoint.EUWest1);

            var lang = _httpContextAccessor.HttpContext?.Items["lang"] as string ?? "es";
            var client = _httpClientFactory.CreateClient("ApiGatewayService");
            var GetIdiomas = await client.GetAsync($"/auth/api/Idioma/GetListIdiomaAll?lang={lang}");
            if (GetIdiomas.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return ResponseApiService.Response(StatusCodes.Status304NotModified, GetIdiomas.RequestMessage);
            }
            var Idiomas = await GetIdiomas.Content.ReadAsStringAsync();
            BaseResponseModel IdiomasaResult = JsonConvert.DeserializeObject<BaseResponseModel>(Idiomas);
            List<IdiomasRequest> IdiomaRequest = IdiomasaResult.Data.ToObject<List<IdiomasRequest>>();

            string idiomatextinical = await GetIdiomaRequest(awsCredentials,textoOring);

            List<TraduccionModel> traduccionModels = new List<TraduccionModel>();

            var idiomastraducir = IdiomaRequest.Where(x => !x.Key.Contains(idiomatextinical)).ToList();

            foreach (var idioma in idiomastraducir)
            {
                // Crear la solicitud de traducción
                var request = new TranslateTextRequest
                {
                    Text = textoOring,
                    SourceLanguageCode = idiomatextinical,
                    TargetLanguageCode = idioma.Key
                };

                // Enviar la solicitud y obtener la respuesta
                var response = await awsClient.TranslateTextAsync(request);

                traduccionModels.Add(new TraduccionModel
                {

                    IdiomaDestino = idioma.Key,
                    IdiomaOrigen = idiomatextinical,
                    TextoOriginal = textoOring,
                    TextoTraducido = response.TranslatedText,

                });

            }
            traduccionModels.Add(new TraduccionModel
            {

                IdiomaDestino = idiomatextinical,
                IdiomaOrigen = idiomatextinical,
                TextoOriginal = textoOring,
                TextoTraducido = textoOring,

            });

            Console.WriteLine($"Texto original: {idiomatextinical}");


            return ResponseApiService.Response(StatusCodes.Status201Created, traduccionModels);

        }

        public async Task<string> GetIdiomaRequest(BasicAWSCredentials awsCredentials, string texto)
        {
            var comprehendClient = new AmazonComprehendClient(awsCredentials,Amazon.RegionEndpoint.USEast1);
            var request = new DetectDominantLanguageRequest
            {
                Text = texto
            };

            var response = await comprehendClient.DetectDominantLanguageAsync(request);
            var lenguajeDominante = response.Languages[0]; // El más probable

            Console.WriteLine($"Idioma detectado: {lenguajeDominante.LanguageCode} (Confianza: {lenguajeDominante.Score:P})");
            // Ejemplo de salida: "Idioma detectado: es (Confianza: 99.50%)"

            return lenguajeDominante.LanguageCode;

        }


    }
}
