
namespace Holcim.AuctionService.Application.Database.Auction.Commands.GetById
{
    public interface IGetAuctionByProviderIdCommandHandler
    {
        Task<object> Execute(Guid auctionId);
    }
}
