using Holcim.Domain.Entities.Acciones;
using Holcim.Domain.Entities.AccionesMenu;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class AccionesMenuConfiguration
    {
        public AccionesMenuConfiguration(EntityTypeBuilder<AccionesMenu> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdAccionesMenu);
        }
    }
}
