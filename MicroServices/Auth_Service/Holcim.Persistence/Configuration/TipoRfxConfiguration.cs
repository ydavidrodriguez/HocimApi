using Holcim.Domain.Entities.Acciones;
using Holcim.Domain.Entities.TipoRfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class TipoRfxConfiguration
    {
        public TipoRfxConfiguration(EntityTypeBuilder<TipoRfx> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTipoRfx);
        }

    }
}
