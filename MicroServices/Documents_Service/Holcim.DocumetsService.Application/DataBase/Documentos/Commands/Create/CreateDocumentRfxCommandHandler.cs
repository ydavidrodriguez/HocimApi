using AutoMapper;
using Holcim.DocumetsService.Application.External;
using Holcim.DocumetsService.Application.Feature;
using Holcim.DocumetsService.Application.Helpers;
using Holcim.DocumetsService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Holcim.DocumetsService.Application.DataBase.Documentos.Commands.Create
{
    public class CreateDocumentRfxCommandHandler : ICreateDocumentRfxCommandHandler
    {

        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IPostEnviarDocuments _PostEnviarDocuments;
        private readonly IDapperProcedure _dapperProcedure;


        public CreateDocumentRfxCommandHandler(IMapper mapper, IConfiguration configuration, 
            IPostEnviarDocuments postEnviarDocuments, IDapperProcedure dapperProcedure)
        {
            _mapper = mapper;
            _config = configuration;
            _PostEnviarDocuments = postEnviarDocuments;
            _dapperProcedure = dapperProcedure;
        }
        public async Task<object> Execute(IFormFile formFile, string jsondata)
        {
            if (formFile.Length > 50 * 1024 * 1024) // 50 MB
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, "El archivo no debe exceder los 50 MB.");
            }
            var datarDocument = JsonConvert.DeserializeObject<JsonDataInitialRfx>(jsondata);
            if(datarDocument.Tipo == "PreguntaRfx") 
            {
                var ParametersRespuestaProveedor = new { Path = datarDocument.Path, IdPregunta = datarDocument.Id };
                _dapperProcedure.UpdateQuery(ParametersRespuestaProveedor, "");
            }
            await _PostEnviarDocuments.PostExecuteDocuments(formFile, datarDocument.Path);

            return ResponseApiService.Response(StatusCodes.Status201Created, "Archivo subido con éxito.");
        }

    }
}
