using Holcim.Domain.Entities.Rfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class RfxTemporalConfiguration
    {
        public RfxTemporalConfiguration(EntityTypeBuilder<RfxTemporal> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRfxTemporal);
        }
    }
}
