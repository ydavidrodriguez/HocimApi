using Holcim.AuctionService.Domain.Models.Subasta;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public interface ICreateListAdjudicarSubastaCommandHandler
    {
        Task<object> Execute(List<PostOtorgarSubasta> postOtorgarSubasta);
    }
}
