namespace Holcim.FileSend.Domain.Models
{
    public class PostCargueItemsRfxResponse
    {
        public string? item { get; set; }
        public Guid PscsId { get; set; }
        public Guid UnidadMediadId { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnd { get; set; }
    }
}
