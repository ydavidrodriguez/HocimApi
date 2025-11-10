using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Pregunta.Commands.List
{
    public class GetQuestionReplyRfxListByProveedorIdCommandHandler : IGetQuestionReplyRfxListByProveedorIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetQuestionReplyRfxListByProveedorIdCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(GetQuestionsProviderByRfxidRequest getQuestionsProviderByRfxidRequest)
        {
            var ParametersRespuestaUsuario = new { Rfxproveedor = getQuestionsProviderByRfxidRequest.IdProveedor, RfxId = getQuestionsProviderByRfxidRequest.IdRfx };
            var listrfxresponse = _dapperProcedure.GetQuery(ParametersRespuestaUsuario,"GETRFXlISTREPLYPROVIDERQUESTIONSDETAILS");
            List<RespuestaPreguntaRfxIdResponse> rfxReplyResponse = JsonConvert.DeserializeObject<List<RespuestaPreguntaRfxIdResponse>>(listrfxresponse);
            return ResponseApiService.Response(StatusCodes.Status201Created, rfxReplyResponse);
        }

    }
}
