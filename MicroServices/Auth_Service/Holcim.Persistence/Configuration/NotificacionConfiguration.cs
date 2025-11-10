using Holcim.Domain.Entities.Notificaciones;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class NotificacionConfiguration
    {
        public NotificacionConfiguration(EntityTypeBuilder<Notificaciones> entityBuilder)
        {
             entityBuilder.HasKey(x => x.IdNotificaciones);
        }

    }
}
