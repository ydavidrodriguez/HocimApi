using Holcim.Domain.Entities.Usuario;
using Holcim.Domain.Entities.UsuarioNotificaciones;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class UsuarioTokenConfiguration
    {
        public UsuarioTokenConfiguration(EntityTypeBuilder<UsuarioToken> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuarioToken);
        }
    }
}
