using Holcim.Domain.Entities.ZonaHoraria;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class ZonaHorarioConfiguration
    {
        public ZonaHorarioConfiguration(EntityTypeBuilder<ZonaHoraria> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdZonaHoraria);
        }

    }
}
