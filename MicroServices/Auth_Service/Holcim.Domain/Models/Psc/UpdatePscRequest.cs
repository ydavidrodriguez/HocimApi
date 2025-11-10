namespace Holcim.Domain.Models.Psc
{
    public class UpdatePscRequest
    {
        public Guid IdPscs { get; set; }
        public string PscsId { get; set; }
        public string PscsNombre { get; set; }
        public Guid CategoriaPscId { get; set; }
        public Guid GrupoPscId { get; set; }
        public bool Estado { get; set; }

    }
}
