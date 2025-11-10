using Holcim.Domain.Entities.Dependencia;
using Holcim.Domain.Entities.Estado;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class EstadoConfiguration
    {
        public EstadoConfiguration(EntityTypeBuilder<Estado> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdEstado);
        }
    }
}
