using Holcim.Domain.Entities.UsuarioNotificaciones;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class UsuarioNotificacionesConfiguration
    {
        public UsuarioNotificacionesConfiguration(EntityTypeBuilder<UsuarioNotificaciones> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuarioNotificaciones);
        }
    }
}
