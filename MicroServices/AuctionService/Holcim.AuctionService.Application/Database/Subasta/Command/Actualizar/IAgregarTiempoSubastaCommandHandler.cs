using Holcim.AuctionService.Domain.Models;
namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public interface IAgregarTiempoSubastaCommandHandler
    {
        Task<object> Execute(PatchAgregarTiempoSubastaRequest request);
    }
}