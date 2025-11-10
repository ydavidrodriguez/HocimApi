namespace Holcim.Domain.Entities.UsuarioNotificaciones
{
    public class UsuarioNotificaciones
    {
        public Guid IdUsuarioNotificaciones { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario.Usuario Usuario { get; set; }
        public Guid NotificacionesId { get; set; }
        public Notificaciones.Notificaciones Notificaciones { get; set; }

    }
}
