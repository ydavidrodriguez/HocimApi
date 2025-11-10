namespace Holcim.AuctionService.Domain.Models
{
    public class Bid
{
    public string AuctionId { get; set; } = string.Empty;
    public string AnonymousName { get; set; } = string.Empty;
    public string RealName { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime Timestamp { get; set; }
}

}
