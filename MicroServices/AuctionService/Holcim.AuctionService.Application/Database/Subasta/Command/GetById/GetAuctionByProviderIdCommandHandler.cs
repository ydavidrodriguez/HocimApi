using AutoMapper;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Auction.Commands.GetById
{
    public class GetAuctionByProviderIdCommandHandler : IGetAuctionByProviderIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;


        public GetAuctionByProviderIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper, IDapperProcedure dapperProcedure)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
        }


        public async Task<object> Execute(Guid userId)
        {
            var parametersActionUser = new { IdUsuario = userId };
            var Subastastring = _dapperProcedure.GetQuery(parametersActionUser, "GETLISTSUBASTABYUSER");
            var Subastalist = JsonConvert.DeserializeObject<List<GetProveedorByUserResponse>>(Subastastring);
            return ResponseApiService.Response(StatusCodes.Status201Created, Subastalist);

        }
    }
}
