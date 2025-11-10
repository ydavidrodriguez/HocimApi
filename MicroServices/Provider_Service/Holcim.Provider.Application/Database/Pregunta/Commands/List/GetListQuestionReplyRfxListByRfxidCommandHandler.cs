using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models;
using Holcim.Provider.Domain.Models.Proveedor;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Pregunta.Commands.List
{
    public class GetListQuestionReplyRfxListByRfxidCommandHandler : IGetListQuestionReplyRfxListByRfxidCommandHandler
    {

        private readonly IDapperProcedure _dapperProcedure;

        public GetListQuestionReplyRfxListByRfxidCommandHandler( IDapperProcedure dapperProcedure)
        {
            _dapperProcedure = dapperProcedure;
        }
        public async Task<object> Execute(Guid rfxid)
        {
            var ParametersListReplyProvider = new { RfxId = rfxid };
            var listrfxrespuestaPreguntaRfxId = _dapperProcedure.GetQuery(ParametersListReplyProvider, "GETRFXREPLYPROVIDER");
            List<GetResponseProviderRfx> rfxReplyResponse = JsonConvert.DeserializeObject<List<GetResponseProviderRfx>>(listrfxrespuestaPreguntaRfxId);
            return ResponseApiService.Response(StatusCodes.Status201Created, rfxReplyResponse);
        }

    }
}
