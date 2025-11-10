using Holcim.AuctionService.Domain.Models.Subasta;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public interface IUpdateFechaPausaSubastaCommandHandler
    {
        Task<object> Execute(PutSubastaFechaPausaRequest putSubastaFechaPausaRequest);
    }
}
