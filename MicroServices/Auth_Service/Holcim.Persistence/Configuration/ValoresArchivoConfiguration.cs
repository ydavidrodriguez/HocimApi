using Holcim.Domain.Entities.Archivos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class ValoresArchivoConfiguration
    {
        public ValoresArchivoConfiguration(EntityTypeBuilder<ValoresArchivo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdValoresArchivo);
        }

    }
}
