using Holcim.AuctionService.Domain.Entities.Ronda;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class ItemsRondaConfiguration
    {
        public ItemsRondaConfiguration(EntityTypeBuilder<ItemsRonda> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdItemsRonda);
        }
    }
}
