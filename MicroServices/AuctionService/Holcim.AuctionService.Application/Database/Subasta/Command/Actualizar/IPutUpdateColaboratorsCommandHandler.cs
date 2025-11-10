using Holcim.AuctionService.Domain.Models;
namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public interface IPutUpdateColaboratorsCommandHandler
    {
        Task<object> Execute(PutUpdateColaboratorsRequest request);
    }
}