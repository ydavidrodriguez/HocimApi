using AutoMapper;
using Holcim.Provider.Application.External;
using Holcim.Provider.Application.Feature;
using Holcim.Provider.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Provider.Application.Database.Proveedor.Commands.List
{
    public class GetListAuctionProviderCommandHandler : IGetListAuctionProviderCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetListAuctionProviderCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure)
        {

            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
        }

        public object Execute(Guid UsuarioId)
        {

            var ParamtersRfxAssignet = new { IDUSUARIO = UsuarioId };
            string resultauctionassignet = _dapperProcedure.GetQuery(ParamtersRfxAssignet, "GETAUCTIONPROVIDERLIST");
            List<AuctionproveedorResponse> resultsacution = JsonConvert.DeserializeObject<List<AuctionproveedorResponse>>(resultauctionassignet);

            return ResponseApiService.Response(StatusCodes.Status201Created, resultsacution);



        }

    }
}
