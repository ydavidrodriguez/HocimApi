namespace Holcim.Domain.Entities.Pscs
{
    public class Pscs
    {
        public Guid IdPscs { get; set; }
        public string PscsId { get; set; } = string.Empty;
        public string PscsNombre { get; set; } = string.Empty;
        public CategoriaPsc CategoriaPsc { get; set; } = new CategoriaPsc();
        public Guid CategoriaPscId { get; set; }
        public GrupoPsc GrupoPsc { get; set; } = new GrupoPsc();
        public Guid GrupoPscId { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }

    }
}
