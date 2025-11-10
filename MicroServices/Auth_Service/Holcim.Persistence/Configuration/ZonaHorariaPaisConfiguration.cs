using Holcim.Domain.Entities.ZonaHoraria;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class ZonaHorariaPaisConfiguration
    {
        public ZonaHorariaPaisConfiguration(EntityTypeBuilder<ZonaHorariaPais> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdZonaHorariaPais);
        }

    }
}
