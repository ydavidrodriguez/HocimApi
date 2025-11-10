using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public class GetListRfxProviderCommandHandler : IGetListRfxProviderCommandHandler
    {

        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetListRfxProviderCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
        }

        public object Execute(Guid  UsuarioId)
        {
            var ParamtersRfxAssignet = new { UsuarioId = UsuarioId };
            string resultrfxassignet = _dapperProcedure.GetQuery(ParamtersRfxAssignet, "GETPROVEEDORRFXASING");
            List<RfxProveedorResponse> rfxProveedorResponses = JsonConvert.DeserializeObject<List<RfxProveedorResponse>>(resultrfxassignet);

            return ResponseApiService.Response(StatusCodes.Status201Created, rfxProveedorResponses);

        }

    }
}
