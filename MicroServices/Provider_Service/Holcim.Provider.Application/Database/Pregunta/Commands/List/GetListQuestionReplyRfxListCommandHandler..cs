using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Pregunta.Commands.List
{
    public class GetListQuestionReplyRfxListCommandHandler : IGetListQuestionReplyRfxListCommandHandler
    {

       
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetListQuestionReplyRfxListCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            
        }
        public async Task<object> Execute()
        {
            var listrfxresponse = _dapperProcedure.GetQuery(null, "GETRFXlISTREPLYPROVIDER");
            List<RfxReplyResponse> rfxReplyResponse = JsonConvert.DeserializeObject<List<RfxReplyResponse>>(listrfxresponse);
            return ResponseApiService.Response(StatusCodes.Status201Created, rfxReplyResponse);
        }

    }
}
