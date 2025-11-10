namespace Holcim.Provider.Domain.Models
{
    public class PreguntaResponse
    {
        public Guid IdPreguntaArchivo { get; set; }
        public string? Pregunta { get; set; }
        public bool? Afirmacion  { get; set; }
        public string? RutaUrl  { get; set; }
        public string? ValoresArchivoJson { get; set; }
        public Guid IdValoresArchivo { get; set; }
        public string? Nombre { get; set; }
        public string? TipoDato { get; set; }
        public bool? Estado { get; set; }

    }
}
