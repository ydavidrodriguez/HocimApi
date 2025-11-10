namespace Holcim.AuctionService.Application.Database.Trazabilidad.Commands
{
    public interface IGetLogsSubastaCommandHandler
    {
        Task<object> Execute(Guid auctionId);
    }
}