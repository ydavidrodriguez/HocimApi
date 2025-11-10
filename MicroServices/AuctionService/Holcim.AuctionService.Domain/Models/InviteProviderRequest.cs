namespace Holcim.AuctionService.Domain.Models.Auction
{
    public class InviteProviderRequest
    {
        public Guid AuctionId { get; set; }
        public List<string> ProviderEmails { get; set; } = new List<string>();
    }
}
