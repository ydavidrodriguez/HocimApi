namespace Holcim.Domain.Entities.TipoArchivo
{
    public class TipoArchivoRfx
    {
        public Guid IdTipoArchivoRfx { get; set; }
        public TipoArchivo TipoArchivo { get; set; }
        public Guid TipoArchivoId { get; set; }
        public TipoRfx.TipoRfx TipoRfx { get; set; }
        public Guid TipoRfxId { get; set; }

    }
}
