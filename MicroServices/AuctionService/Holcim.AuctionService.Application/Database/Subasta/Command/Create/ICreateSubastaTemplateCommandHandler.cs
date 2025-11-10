using Holcim.AuctionService.Domain.Models;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Create
{
    public interface ICreateSubastaTemplateCommandHandler
    {
        Task<object> Execute(PostCreateSubastaRequest postCreateSubastaRequest);
    }
}
