namespace Holcim.Provider.Domain.Models
{
    public class RespuestaPreguntaRequest
    {
        public Guid RfxId { get; set; }
        public Guid ProveedorId { get; set; }
        public Guid? PreguntaArchivoId { get; set; }
        public string? Respuesta { get; set; }
        public Guid? ItemId { get; set; }
        public string? UrlArchivo { get; set; }

    }
}
