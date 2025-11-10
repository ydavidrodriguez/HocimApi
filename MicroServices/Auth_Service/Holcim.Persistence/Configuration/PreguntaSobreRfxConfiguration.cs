using Holcim.Domain.Entities.PreguntaArchivo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class PreguntaSobreRfxConfiguration
    {
        public PreguntaSobreRfxConfiguration(EntityTypeBuilder<PreguntaSobreRfx> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPreguntaSobreRfx);
        }
    }
}
