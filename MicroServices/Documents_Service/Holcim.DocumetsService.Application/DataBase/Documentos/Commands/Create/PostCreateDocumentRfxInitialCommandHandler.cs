using System.Net.Http.Json;
using AutoMapper;
using Holcim.DocumetsService.Application.Feature;
using Holcim.DocumetsService.Application.Helpers;
using Holcim.DocumetsService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Create
{
    public class PostCreateDocumentRfxInitialCommandHandler : IPostCreateDocumentRfxInitialCommandHandler
    {

        private readonly IPostEnviarDocuments _PostEnviarDocuments;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostCreateDocumentRfxInitialCommandHandler(IMapper mapper,
            IConfiguration configuration, IPostEnviarDocuments postEnviarDocuments,
            IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _PostEnviarDocuments = postEnviarDocuments;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<object> Execute(IFormFile formFile, string jsondata)
        {
            if (formFile.Length > 50 * 1024 * 1024) // 50 MB
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, "El archivo no debe exceder los 50 MB.");
            }

            var client = _httpClientFactory.CreateClient("ApiGatewayService");
            var lang = _httpContextAccessor.HttpContext?.Items["lang"] as string ?? "es";

            JsonDataInitialRfx datarfx = JsonConvert.DeserializeObject<JsonDataInitialRfx>(jsondata);
            datarfx.Path = datarfx.Path + "/" + formFile.FileName.Replace(" ","_");
            BaseResponseModel response = (BaseResponseModel)await _PostEnviarDocuments.PostExecuteDocuments(formFile, datarfx.Path);
            if (response != null)
            {
                if (response.StatusCode == StatusCodes.Status201Created)
                {
                    var rfxUpdate = new RfxUpdatePathModel
                    {
                        IdRfx = datarfx.Id,
                        Path = datarfx.Path
                    };
                    var updatepath = await client.PutAsJsonAsync($"/auth/api/Rfx/PutUpdatePathRfxCommandHandler?lang={lang}", rfxUpdate);
                    if (updatepath.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return ResponseApiService.Response(StatusCodes.Status304NotModified, updatepath.RequestMessage);
                    }
                }
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Archivo subido con éxito.");
        }

    }
}
