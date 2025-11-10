namespace Holcim.Domain.Entities.Archivos
{
    public class ArchivoSobre
    {
        public Guid IdArchivo { get; set; }
        public string? NombreArchivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estado { get; set; } 
        public TipoArchivo.TipoArchivo TipoArchivo { get; set; } = new TipoArchivo.TipoArchivo();
        public Guid TipoArchivoId { get; set; } 
  

    }
}
