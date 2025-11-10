namespace Holcim.AuctionService.Application.Database.Auction.Commands.List
{
    public interface IListAuctionsCommandHandler
    {
        Task<object> Execute(string? Nombre, Guid? EstadoId);
    }
}
