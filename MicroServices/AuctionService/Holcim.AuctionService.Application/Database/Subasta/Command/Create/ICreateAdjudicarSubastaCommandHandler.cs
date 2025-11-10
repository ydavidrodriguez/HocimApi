using Holcim.AuctionService.Domain.Models.Subasta;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public interface ICreateAdjudicarSubastaCommandHandler
    {
        Task<object> Execute(PostOtorgarSubasta postOtorgarSubasta);
    }
}
