using AutoMapper;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Auction.Commands.List
{
    public class ListAuctionsCommandHandler : IListAuctionsCommandHandler
    {
        private readonly IDapperProcedure _dapperProcedure;

        public ListAuctionsCommandHandler(IDapperProcedure dapperProcedure)
        {
            _dapperProcedure = dapperProcedure;
        }


        public async Task<object> Execute(string? Nombre, Guid? EstadoId)
        {

            var parametersSubasta = new { Nombre = Nombre, Estado = EstadoId };
            var Subastastring = _dapperProcedure.GetQuery(parametersSubasta, "GETLISTSUBASTA");
            var Subastalist = JsonConvert.DeserializeObject<List<GetListAuctionAllResponse>>(Subastastring);
            return ResponseApiService.Response(StatusCodes.Status201Created, Subastalist);


        }
    }
}
