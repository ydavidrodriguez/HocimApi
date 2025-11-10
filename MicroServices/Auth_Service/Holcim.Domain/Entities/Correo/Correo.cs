namespace Holcim.Domain.Entities.Correo
{
    public class Correo
    {
        public Guid IdCorreo { get; set; }
        public string? Descripcion { get; set; }
        public string? Html { get; set; }
        public bool Estado { get; set; }

    }
}
