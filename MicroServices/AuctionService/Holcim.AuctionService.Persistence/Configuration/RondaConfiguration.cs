using Holcim.AuctionService.Domain.Entities.Ronda;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class RondaConfiguration
    {
        public RondaConfiguration(EntityTypeBuilder<Ronda> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRonda);
        }

    }
}
