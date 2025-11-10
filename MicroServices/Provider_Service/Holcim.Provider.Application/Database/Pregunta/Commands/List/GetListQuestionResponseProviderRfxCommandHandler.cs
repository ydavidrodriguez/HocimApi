using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models;
using Holcim.Provider.Domain.Models.Pregunta;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Pregunta.Commands.List
{
    public class GetListQuestionResponseProviderRfxCommandHandler : IGetListQuestionResponseProviderRfxCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetListQuestionResponseProviderRfxCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(Guid rfxid)
        {
            var ParametersListReplyProvider = new { RfxId = rfxid };
            var listrfxrespuestaPreguntaRfxId = _dapperProcedure.GetQuery(ParametersListReplyProvider, "GETRFXlISTREPLYPROVIDERQUESTIONS");
            List<RespuestaProveedorRfxIdResponse> rfxReplyResponse = JsonConvert.DeserializeObject<List<RespuestaProveedorRfxIdResponse>>(listrfxrespuestaPreguntaRfxId);

            List<QuestionResponseProviderRfxResponse> questionResponseProviderRfxResponses = new List<QuestionResponseProviderRfxResponse>(); 

            foreach (var item in rfxReplyResponse)
            {
                QuestionResponseProviderRfxResponse questionResponseProviderRfxResponse = new QuestionResponseProviderRfxResponse();

                RespuestaProveedorRfxIdResponse  respuestaProveedorRfxIdResponse =  new RespuestaProveedorRfxIdResponse();

                respuestaProveedorRfxIdResponse.IdProveedor = item.IdProveedor;
                respuestaProveedorRfxIdResponse.Correo= item.Correo;
                respuestaProveedorRfxIdResponse.NombreEmpresa= item.NombreEmpresa;
                respuestaProveedorRfxIdResponse.RegistroMercantil= item.RegistroMercantil;
                respuestaProveedorRfxIdResponse.Observacion = item.Observacion;
                respuestaProveedorRfxIdResponse.Calificacion = item.Calificacion;
                questionResponseProviderRfxResponse.RespuestaProveedorRfxIdResponse = respuestaProveedorRfxIdResponse;

                var ParametersQuestionResponseProvider = new { ProveedorId = item.IdProveedor, RfxId = rfxid };
                var listQuestionResponseProvider = _dapperProcedure.GetQuery(ParametersQuestionResponseProvider, "GETRESPONSEQUESTIONPROVIDER");
                List<QuestionResponseProviderResponse> QuestionResponseProvider = JsonConvert.DeserializeObject<List<QuestionResponseProviderResponse>>(listQuestionResponseProvider);

                questionResponseProviderRfxResponse.QuestionResponseProviderResponse = QuestionResponseProvider;

                var listquestionitemprovider = _dapperProcedure.GetQuery(ParametersQuestionResponseProvider, "GETRESPONSEITEMPROVIDER");
                List<QuestionResponseProviderItems> QuestionResponseItemProvider = JsonConvert.DeserializeObject<List<QuestionResponseProviderItems>>(listquestionitemprovider);
                questionResponseProviderRfxResponse.QuestionResponseProviderItems = QuestionResponseItemProvider;

                questionResponseProviderRfxResponses.Add(questionResponseProviderRfxResponse);

            }

            return ResponseApiService.Response(StatusCodes.Status201Created, questionResponseProviderRfxResponses);
           
        }

    }
}
