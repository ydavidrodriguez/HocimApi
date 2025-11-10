using Holcim.Domain.Entities.Rol;
using Holcim.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class UsuarioConfiguration
    {
        public UsuarioConfiguration(EntityTypeBuilder<Usuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuario);
        }

    }
}
