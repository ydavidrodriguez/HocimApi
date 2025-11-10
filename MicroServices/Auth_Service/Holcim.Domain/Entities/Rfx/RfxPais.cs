namespace Holcim.Domain.Entities.Rfx
{
    public class RfxPais
    {
        public Guid IdRfxPais { get; set; }
        public Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
        public Pais.Pais Pais { get; set; }
        public Guid PaisId { get; set; }

    }
}
