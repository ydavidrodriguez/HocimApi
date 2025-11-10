namespace Holcim.Domain.Models.Informes
{
    public class UpdateInformesRequest
    {
        public Guid IdInformes { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }
}
