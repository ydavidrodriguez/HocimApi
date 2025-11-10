using Holcim.Domain.Entities.Rfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class RfxPaisConfiguration
    {
        public RfxPaisConfiguration(EntityTypeBuilder<RfxPais> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRfxPais);
        }
    }
}
