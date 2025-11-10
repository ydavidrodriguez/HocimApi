using Holcim.AuctionService.Domain.Models.Subasta;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public interface IUpdateReanudarSubastaCommandHandler
    {
        Task<object> Execute(PutSubastaFechaPausaRequest putSubastaFechaPausaRequest);
    }
}
