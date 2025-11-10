using Holcim.Domain.Entities.Rol;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class RolConfiguration
    {
        public RolConfiguration(EntityTypeBuilder<Rol> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRol);
        }
    }
}
