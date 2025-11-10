using Holcim.AuctionService.Domain.Models;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update;

public interface IUpdateSubastaCommandHandler
{
    Task<object> Execute(PostUpdateSubastaRequest request);
}