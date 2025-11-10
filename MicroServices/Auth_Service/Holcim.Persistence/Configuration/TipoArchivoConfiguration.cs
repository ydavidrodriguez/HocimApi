using Holcim.Domain.Entities.TipoArchivo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class TipoArchivoConfiguration
    {
        public TipoArchivoConfiguration(EntityTypeBuilder<TipoArchivo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTipoArchivo);
        }
    }
}
