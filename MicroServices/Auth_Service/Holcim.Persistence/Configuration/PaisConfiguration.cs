using Holcim.Domain.Entities.Pais;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class PaisConfiguration
    {
        public PaisConfiguration(EntityTypeBuilder<Pais> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPais);
        }

    }
}
