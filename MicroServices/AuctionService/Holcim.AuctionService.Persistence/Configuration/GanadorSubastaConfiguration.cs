using Holcim.AuctionService.Domain.Entities.GanadorSubasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class GanadorSubastaConfiguration
    {
        public GanadorSubastaConfiguration(EntityTypeBuilder<GanadorSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdGanadorSubasta);
        }

    }
}
