
namespace Holcim.AuctionService.Application.Database.Auction.Commands.GetById
{
    public interface IGetOffertByAuctionIdCommandHandler
    {
        Task<object> Execute(Guid auctionId, Guid? userId);
    }
}
