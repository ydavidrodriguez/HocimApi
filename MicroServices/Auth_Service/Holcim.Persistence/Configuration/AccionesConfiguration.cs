using Holcim.Domain.Entities.Acciones;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class AccionesConfiguration
    {
        public AccionesConfiguration(EntityTypeBuilder<Acciones> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdAcciones);
        }
    }
}
