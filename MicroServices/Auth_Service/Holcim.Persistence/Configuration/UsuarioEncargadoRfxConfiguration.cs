using Holcim.Domain.Entities.Rfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class UsuarioEncargadoRfxConfiguration
    {
        public UsuarioEncargadoRfxConfiguration(EntityTypeBuilder<UsuarioEncargadoRfx> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuarioEncargadoRfx);
        }

    }
}
