using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class ArchivosConfiguration
    {
        public ArchivosConfiguration(EntityTypeBuilder<Domain.Entities.Archivos.ArchivoSobre> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdArchivo);
        }
    }
}
