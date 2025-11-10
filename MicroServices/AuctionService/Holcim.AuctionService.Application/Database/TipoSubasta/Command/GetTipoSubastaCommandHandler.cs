using AutoMapper;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.AuctionService.Application.Database.TipoSubasta.Commands
{
    public class GetTipoSubastaCommandHandler : IGetTipoSubastaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetTipoSubastaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute()
        {
            var tipoSubasta = _dataBaseService.TipoSubasta.AsQueryable();

            var tipoSubastaList = tipoSubasta.ToList();

            return ResponseApiService.Response(StatusCodes.Status200OK, tipoSubastaList);
        }
    }
}
