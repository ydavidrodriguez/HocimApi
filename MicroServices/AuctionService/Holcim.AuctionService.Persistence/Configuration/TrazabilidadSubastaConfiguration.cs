using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class TrazabilidadSubastaConfiguration
    {
        public TrazabilidadSubastaConfiguration(EntityTypeBuilder<TrazabilidadSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTrazabilidadSubasta);
        }
    }
}
