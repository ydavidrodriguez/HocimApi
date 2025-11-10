using Holcim.Domain.Entities.Acciones;
using Holcim.Domain.Entities.UnidadMedida;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class UnidadMedidaConfiguration
    {
        public UnidadMedidaConfiguration(EntityTypeBuilder<UnidadMedida> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUnidadMedida);
        }

    }
}
