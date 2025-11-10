namespace Holcim.Domain.Entities.TipoArchivo
{
    public class TipoArchivo
    {
        public Guid IdTipoArchivo { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estado { get; set; }

    }
}
