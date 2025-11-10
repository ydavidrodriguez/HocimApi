using Holcim.AuctionService.Domain.Models;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public interface ICreateOfferCommandHandler
    {
        Task<object> Execute(PostCreateOfferRequest request);
    }
}
