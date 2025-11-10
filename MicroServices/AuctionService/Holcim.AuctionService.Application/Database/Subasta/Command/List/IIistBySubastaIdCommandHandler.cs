namespace Holcim.AuctionService.Application.Database.Subasta.Command.List
{
    public interface IIistBySubastaIdCommandHandler
    {
        Task<object> Execute(Guid SubastaId);
    }
}
