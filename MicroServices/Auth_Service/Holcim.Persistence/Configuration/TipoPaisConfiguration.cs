using Holcim.Domain.Entities.AccionesMenu;
using Holcim.Domain.Entities.TipoPais;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class TipoPaisConfiguration
    {
        public TipoPaisConfiguration(EntityTypeBuilder<TipoPais> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTipoPais);
        }

    }
}
