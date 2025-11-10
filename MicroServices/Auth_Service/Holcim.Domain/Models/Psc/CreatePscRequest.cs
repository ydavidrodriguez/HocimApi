namespace Holcim.Domain.Models.Psc
{
    public class CreatePscRequest
    {
        public string PscsId { get; set; }
        public string PscsNombre { get; set; }
        public Guid CategoriaPscId { get; set; }
        public Guid GrupoPscId { get; set; }

    }
}
