namespace Holcim.Domain.Entities.TipoUsuario
{
    public class TipoUsuario
    {
        public Guid IdTipoUsuario { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
