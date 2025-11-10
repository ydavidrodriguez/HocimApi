using Holcim.AuctionService.Domain.Models.Auction;
namespace Holcim.AuctionService.Application.Database.Auction.Commands.Invite
{
    public interface IInviteProviderCommandHandler
    {
        Task<object> Execute(InviteProviderRequest inviteProviderRequest);
    }
}