using Holcim.AuctionService.Domain.Models;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public interface ICreateSubastaCommandHandler
    {
        Task<object> Execute(PostCreateSubastaRequest postCreateSubastaRequest);
    }
}
