namespace Holcim.Provider.Domain.Models.Pregunta
{
    public class QuestionResponseProviderResponse
    {
        public Guid IdPreguntaArchivo { get; set; }
        public string? Pregunta { get; set; }
        public bool Requerido { get; set; }
        public string? RutaUrl { get; set; }
        public string? Respuesta { get; set; }
        public string? UrlArchivo { get; set; }
        public Guid? IdItem { get; set; }
        public string Nombre { get; set; }
    }
}
