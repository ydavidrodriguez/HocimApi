using Holcim.Domain.Entities.TipoEstado;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class TipoEstadoConfiguration
    {
        public TipoEstadoConfiguration(EntityTypeBuilder<TipoEstado> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTipoEstado);
        }
    }
}
