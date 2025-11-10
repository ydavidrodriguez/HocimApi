using Holcim.AuctionService.Domain.Entities.ProveedorSubasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class ProveedorSubastaConfiguration
    {
        public ProveedorSubastaConfiguration(EntityTypeBuilder<ProveedorSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdProveedorSubasta);
        }

    }
}
