namespace Holcim.Provider.Domain.Models
{
    public class RespuestaPreguntaRfxIdResponse
    {
        public bool Requerido { get; set; }
        public Guid IdPreguntaArchivo { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public Guid? IdItem { get; set; }
        public string? Nombre { get; set; }

    }
}
