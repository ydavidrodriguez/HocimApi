using Holcim.Domain.Entities.Item;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class ItemDetalleConfiguration
    {
        public ItemDetalleConfiguration(EntityTypeBuilder<ItemDetalle> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdItemDetalle);
        }
    }
}
