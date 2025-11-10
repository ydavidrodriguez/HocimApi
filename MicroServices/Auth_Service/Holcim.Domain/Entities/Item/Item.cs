namespace Holcim.Domain.Entities.Item
{
    public class Item
    {
        public Guid IdItem { get; set; }
        public  string Nombre { get; set; }
        public bool Estado { get; set; }
        public int? Index { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}