namespace Holcim.Provider.Domain.Entities
{
    public class RespuestaPregunta
    {
        public Guid IdRespuestaPregunta { get; set; }
        public Guid RfxId { get; set; }
        public Guid ProveedorId { get; set; }
        public Guid? PreguntaArchivoId { get; set; }
        public Guid? ItemId { get; set; }
        public string? Respuesta { get; set; }
        public string? UrlArchivo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
