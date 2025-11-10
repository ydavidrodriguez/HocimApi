
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Models.Ronda;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Ronda.Commands.Get;

public class GetLastRoundItemsCommandHandler : IGetLastRoundItemsCommandHandler
{
    private readonly IDataBaseService _dataBaseService;
    private readonly IDapperProcedure _dapperProcedure;

    public GetLastRoundItemsCommandHandler(IDataBaseService dataBaseService, 
        IDapperProcedure dapperProcedure)
    {
        _dataBaseService = dataBaseService;
        _dapperProcedure = dapperProcedure;
    }

    public async Task<object> Execute(Guid subastaId)
    {
        //comment
        var parameter = new {AuctionId = subastaId};
        var itemsString = _dapperProcedure.GetQuery(parameter, "GETLASTROUNDOFFERBYAUCTIONID");
        var items = JsonConvert.DeserializeObject<List<NuevaOfertaModel>>(itemsString);

        return ResponseApiService.Response(StatusCodes.Status200OK, items);
    }
}