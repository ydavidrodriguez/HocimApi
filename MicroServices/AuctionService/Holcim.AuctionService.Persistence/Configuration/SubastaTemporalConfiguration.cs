using Holcim.AuctionService.Domain.Entities.Region;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class SubastaTemporalConfiguration
    {
        public SubastaTemporalConfiguration(EntityTypeBuilder<SubastaTemporal> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdSubastaTemporal);
        }
    }
}
