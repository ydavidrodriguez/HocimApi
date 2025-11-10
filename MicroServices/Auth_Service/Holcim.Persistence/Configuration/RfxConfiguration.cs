using Holcim.Domain.Entities.Acciones;
using Holcim.Domain.Entities.Rfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class RfxConfiguration
    {
        public RfxConfiguration(EntityTypeBuilder<Rfx> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRfx);
        }

    }
}
