using Holcim.Domain.Entities.Pscs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class GrupoPscsConfiguration
    {
        public GrupoPscsConfiguration(EntityTypeBuilder<GrupoPsc> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdGrupoPsc);
        }
    }
}
