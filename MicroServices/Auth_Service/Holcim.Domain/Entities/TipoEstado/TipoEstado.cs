namespace Holcim.Domain.Entities.TipoEstado
{
    public class TipoEstado
    {
        public Guid IdTipoEstado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estado { get; set; }

    }
}
