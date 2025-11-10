namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public interface IActualizarEstadoSubastaCommandHandler
    {
        Task<object> Execute(ActualizarEstadoBaseRequest request);

    }
}