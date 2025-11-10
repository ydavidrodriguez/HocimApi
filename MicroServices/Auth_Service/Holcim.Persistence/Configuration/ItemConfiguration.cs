using Holcim.Domain.Entities.Informes;
using Holcim.Domain.Entities.Item;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class ItemConfiguration
    {
        public ItemConfiguration(EntityTypeBuilder<Item> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdItem);
        }


    }
}
