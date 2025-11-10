namespace Holcim.AuctionService.Application.Database.ZonaHoraria.Commands
{
    public interface IGetZonaHorariaCommandHandler
    {
        Task<object> Execute();
    }
}