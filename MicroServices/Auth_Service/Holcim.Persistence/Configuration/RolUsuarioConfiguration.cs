using Holcim.Domain.Entities.AccionesMenu;
using Holcim.Domain.Entities.Rol;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class RolUsuarioConfiguration
    {
        public RolUsuarioConfiguration(EntityTypeBuilder<RolUsuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRolUsuario);
        }
    }
}
