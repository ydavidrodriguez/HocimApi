using Holcim.Domain.Entities.Acciones;
using Holcim.Domain.Entities.Rfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class RfxItemConfiguration
    {
        public RfxItemConfiguration(EntityTypeBuilder<RfxItem> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRfxItem);
        }


    }
}
