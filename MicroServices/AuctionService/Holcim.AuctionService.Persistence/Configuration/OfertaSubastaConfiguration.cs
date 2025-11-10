using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class OfertaSubastaConfiguration
    {
        public OfertaSubastaConfiguration(EntityTypeBuilder<OfertaSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdOfertaSubasta);
        }
    }
}
