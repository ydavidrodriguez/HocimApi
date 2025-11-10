using Holcim.Domain.Entities.Rfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class TrazabilidadRfxConfiguration
    {
        public TrazabilidadRfxConfiguration(EntityTypeBuilder<TrazabilidadRfx> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTrazabilidadRfx);
        }
    }
}
