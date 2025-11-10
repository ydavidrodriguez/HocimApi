using Holcim.Domain.Entities.TipoArchivo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class TipoArchivoRfxConfiguration
    {
        public TipoArchivoRfxConfiguration(EntityTypeBuilder<TipoArchivoRfx> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTipoArchivoRfx);
        }
    }
}
