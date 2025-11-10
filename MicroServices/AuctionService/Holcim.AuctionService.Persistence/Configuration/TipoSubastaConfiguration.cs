using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class TipoSubastaConfiguration
    {
        public TipoSubastaConfiguration(EntityTypeBuilder<TipoSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTipoSubasta);
        }
    }
}
