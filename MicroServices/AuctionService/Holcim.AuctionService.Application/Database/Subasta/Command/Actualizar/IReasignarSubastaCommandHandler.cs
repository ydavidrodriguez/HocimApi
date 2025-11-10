using Holcim.AuctionService.Domain.Models;
namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public interface IReasignarSubastaCommandHandler
    {
        Task<object> Execute(PutReasignarSubastaRequest request);
    }
}