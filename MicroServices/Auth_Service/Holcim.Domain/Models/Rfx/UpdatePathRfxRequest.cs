namespace Holcim.Domain.Models.Rfx
{
    public class UpdatePathRfxRequest
    {
        public Guid IdRfx { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}
