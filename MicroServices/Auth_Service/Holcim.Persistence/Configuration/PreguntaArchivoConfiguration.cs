using Holcim.Domain.Entities.PreguntaArchivo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class PreguntaArchivoConfiguration
    {
        public PreguntaArchivoConfiguration(EntityTypeBuilder<PreguntaArchivo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPreguntaArchivo);
        }
    }
}
