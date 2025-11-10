namespace Holcim.Domain.Models.Pregunta
{
    public class CrearPregunta
    {
        public Guid? ValoresArchivoId { get; set; }
        public string? Pregunta { get; set; }
        public string? Detalle { get; set; }
        public List<string>? ValoresArchivoJson { get; set; }
        public bool? Afirmacion { get; set; }
        public bool? Requerido { get; set; }
        public Guid? PreguntaArchivoId { get; set; }

    }
}
