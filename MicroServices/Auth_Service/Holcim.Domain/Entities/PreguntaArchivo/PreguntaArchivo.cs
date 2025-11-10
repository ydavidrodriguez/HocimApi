using Holcim.Domain.Entities.Archivos;

namespace Holcim.Domain.Entities.PreguntaArchivo
{
    public class PreguntaArchivo
    {
        public Guid IdPreguntaArchivo { get; set; }
        public string? Pregunta { get; set; }
        public ValoresArchivo ValoresArchivo { get; set; }
        public Guid ValoresArchivoId { get; set; }
        public string? ValoresArchivoJson { get; set; }
        public string? RutaUrl { get; set; }
        public bool? Afirmacion { get; set; }
        public bool Requerido { get; set; }
        public string? Detalle { get; set; }
        public ArchivoSobre? ArchivoSobre { get; set; }
        public Guid? ArchivoSobreId { get; set; }
    }
}
