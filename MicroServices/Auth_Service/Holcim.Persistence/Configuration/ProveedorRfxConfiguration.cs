using Holcim.Domain.Entities.ProveedorRfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class ProveedorRfxConfiguration
    {
        public ProveedorRfxConfiguration(EntityTypeBuilder<ProveedorRfx> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdProveedorRfx);
        }
    }
}
