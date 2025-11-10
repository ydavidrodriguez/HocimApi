using Holcim.AuctionService.Domain.Entities.ItemSubasta;
using Holcim.AuctionService.Domain.Entities.Region;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class RegionSubastaConfiguration
    {
        public RegionSubastaConfiguration(EntityTypeBuilder<PaisSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPaisSubasta);
        }

    }
}
