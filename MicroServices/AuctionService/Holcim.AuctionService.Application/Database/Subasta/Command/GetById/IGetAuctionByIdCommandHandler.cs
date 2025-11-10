
namespace Holcim.AuctionService.Application.Database.Auction.Commands.GetById
{
    public interface IGetAuctionByIdCommandHandler
    {
        Task<object> Execute(Guid subastaId, Guid? usuarioId);
    }
}
