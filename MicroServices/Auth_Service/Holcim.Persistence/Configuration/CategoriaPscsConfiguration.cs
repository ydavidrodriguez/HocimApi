using Holcim.Domain.Entities.Cargo;
using Holcim.Domain.Entities.Pscs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class CategoriaPscsConfiguration
    {
        public CategoriaPscsConfiguration(EntityTypeBuilder<CategoriaPsc> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdCategoriaPsc);
        }

    }
}
