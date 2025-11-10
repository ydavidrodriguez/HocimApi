using Holcim.Domain.Entities.Informes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class InformesConfiguration
    {
        public InformesConfiguration(EntityTypeBuilder<Informes> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdInformes);
        }


    }
}
