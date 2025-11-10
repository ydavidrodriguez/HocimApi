namespace Holcim.Domain.Entities.Rfx
{
    public class RfxItem
    {
        public Guid IdRfxItem { get; set; }
        public Item.Item Item { get; set; }
        public Guid ItemId { get; set; }
        public Rfx Rfx { get; set; }
        public Guid RfxId { get; set; }
       
        public bool Estado { get; set; }    

    }
}
