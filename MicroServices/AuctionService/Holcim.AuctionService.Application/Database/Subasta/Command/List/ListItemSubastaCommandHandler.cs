using AutoMapper;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.List
{
    public class ListItemSubastaCommandHandler : IListItemSubastaCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public ListItemSubastaCommandHandler(IDataBaseService dataBaseService, IMapper mapper, IDapperProcedure dapperProcedure)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
        }


        public async Task<object> Execute(Guid IdSubasta)
        {
            var parametersIdSubasta = new { SUBASTAID = IdSubasta };
            var Subastastring = _dapperProcedure.GetQuery(parametersIdSubasta, "GETITEMSUBASTAREQUEST");
            var Subastalist = JsonConvert.DeserializeObject<List<GetListAuctionAllResponse>>(Subastastring);
            return ResponseApiService.Response(StatusCodes.Status201Created, Subastalist);

        }

    }
}
