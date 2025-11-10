using Holcim.Domain.Entities.Informes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class InformesRolConfiguration
    {
        public InformesRolConfiguration(EntityTypeBuilder<InformesRol> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdInformesRol);
        }
    }
}
