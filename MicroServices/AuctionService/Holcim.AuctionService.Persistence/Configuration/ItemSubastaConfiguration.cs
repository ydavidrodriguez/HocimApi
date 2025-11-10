using Holcim.AuctionService.Domain.Entities.ItemSubasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class ItemSubastaConfiguration
    {
        public ItemSubastaConfiguration(EntityTypeBuilder<ItemSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdItemSubasta);
        }

    }
}
