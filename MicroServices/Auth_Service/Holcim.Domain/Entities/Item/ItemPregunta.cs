using Holcim.Domain.Entities.PreguntaArchivo;

namespace Holcim.Domain.Entities.Item
{
    public class ItemPregunta
    {
        public Guid IdItemPregunta { get; set; }
        public Item Item { get; set; }
        public Guid ItemId { get; set; }
        public PreguntaArchivo.PreguntaArchivo preguntaArchivo { get; set; }
        public Guid preguntaArchivoId { get; set; }

    }
}
