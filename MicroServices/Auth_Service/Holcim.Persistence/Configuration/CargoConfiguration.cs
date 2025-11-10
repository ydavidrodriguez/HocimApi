using Holcim.Domain.Entities.AccionesMenu;
using Holcim.Domain.Entities.Cargo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class CargoConfiguration
    {
        public CargoConfiguration(EntityTypeBuilder<Cargo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdCargo);
        }
    }
}
