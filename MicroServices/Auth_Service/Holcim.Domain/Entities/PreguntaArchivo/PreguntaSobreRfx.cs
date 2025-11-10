namespace Holcim.Domain.Entities.PreguntaArchivo
{
    public class PreguntaSobreRfx
    {
        public Guid IdPreguntaSobreRfx { get; set; }
        public Rfx.Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
        public PreguntaArchivo PreguntaArchivo { get; set; }
        public Guid PreguntaArchivoId { get; set; }

    }
}
