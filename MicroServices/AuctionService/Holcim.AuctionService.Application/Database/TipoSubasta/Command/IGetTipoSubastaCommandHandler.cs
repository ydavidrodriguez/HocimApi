namespace Holcim.AuctionService.Application.Database.TipoSubasta.Commands
{
    public interface IGetTipoSubastaCommandHandler
    {
        Task<object> Execute();
    }
}