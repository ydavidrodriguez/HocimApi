using Holcim.AuctionService.Domain.Entities.Subasta;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Delete
{
    public interface IDeleteAdjudicarSubastaCommandHandle
    {
        Task<object> Execute(DeleteOtorgadoRequest deleteOtorgadoRequest);
    }
}
