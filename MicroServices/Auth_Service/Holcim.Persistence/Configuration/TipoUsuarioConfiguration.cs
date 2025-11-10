using Holcim.Domain.Entities.Rol;
using Holcim.Domain.Entities.TipoUsuario;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class TipoUsuarioConfiguration
    {
        public TipoUsuarioConfiguration(EntityTypeBuilder<TipoUsuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTipoUsuario);
        }

    }
}
