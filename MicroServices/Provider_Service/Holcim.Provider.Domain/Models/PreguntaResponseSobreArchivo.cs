namespace Holcim.Provider.Domain.Models
{
    public class PreguntaResponseSobreArchivo
    {
        public Guid IdPreguntaArchivo { get; set; }
        public string? Pregunta { get; set; }
        public bool? Afirmacion { get; set; }
        public bool? Requerido { get; set; }
        public string? RutaUrl { get; set; }
        public string? ValoresArchivoJson { get; set; }
        public Guid ValoresArchivoId { get; set; }
        public string? Nombre { get; set; }
        public string? TipoDato { get; set; }
        public string? Detalle { get; set; }

    }
}
