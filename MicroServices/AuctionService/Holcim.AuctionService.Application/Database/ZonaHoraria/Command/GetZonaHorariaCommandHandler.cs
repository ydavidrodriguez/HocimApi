using Newtonsoft.Json;
using Holcim.AuctionService.Application.Feature;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Dapper;
using Holcim.AuctionService.Application.External;
using SubastaNamespace = Holcim.AuctionService.Domain.Entities.Subasta;

namespace Holcim.AuctionService.Application.Database.ZonaHoraria.Commands
{
    public class GetZonaHorariaCommandHandler : IGetZonaHorariaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetZonaHorariaCommandHandler(IDataBaseService dataBaseService, IMapper mapper,IDapperProcedure dapperProcedure)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute()
        {
            //var ZonaHoraria = _dataBaseService.ZonaHoraria.AsQueryable();

            //var ZonaHorariaList = ZonaHoraria.ToList();

            return ResponseApiService.Response(StatusCodes.Status200OK, null);
        }
    }
}
