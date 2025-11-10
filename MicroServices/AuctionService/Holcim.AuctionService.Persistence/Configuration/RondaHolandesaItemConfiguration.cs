using Holcim.AuctionService.Domain.Entities.Ronda;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class RondaHolandesaItemConfiguration
    {
        public RondaHolandesaItemConfiguration(EntityTypeBuilder<RondaHolandesaItem> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRondaHolandesaItem);
        }

    }
}
