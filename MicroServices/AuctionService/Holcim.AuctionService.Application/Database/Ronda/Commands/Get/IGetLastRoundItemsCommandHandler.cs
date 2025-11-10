namespace Holcim.AuctionService.Application.Database.Ronda.Commands.Get;

public interface IGetLastRoundItemsCommandHandler
{
    Task<object> Execute(Guid subastaId);
}