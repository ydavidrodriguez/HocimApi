using AutoMapper;
using Holcim.DocumetsService.Application.Feature;
using Holcim.DocumetsService.Application.Helpers;
using Holcim.DocumetsService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Subasta.Create
{
    internal class PostInitialDocumentSubastaCommandHandler : IPostInitialDocumentSubastaCommandHandler
    {
        private readonly IPostEnviarDocuments _PostEnviarDocuments;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostInitialDocumentSubastaCommandHandler(IMapper mapper,
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

            JsonDataInitialRfx dataSubasta = JsonConvert.DeserializeObject<JsonDataInitialRfx>(jsondata);
            dataSubasta.Path = dataSubasta.Path + "/" + formFile.FileName.Replace(" ", "_");
            BaseResponseModel response = (BaseResponseModel)await _PostEnviarDocuments.PostExecuteDocuments(formFile, dataSubasta.Path);
            if (response != null)
            {
                if (response.StatusCode == StatusCodes.Status201Created)
                {
                    var rfxUpdate = new SubastaUpdatePathModel
                    {
                        IdSubasta = dataSubasta.Id,
                        Path = dataSubasta.Path
                    };
                    var updatepath = await client.PutAsJsonAsync($"/auction/api/Subasta/PutUpdatePathSubastaCommandHandler?lang={lang}", rfxUpdate);
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
