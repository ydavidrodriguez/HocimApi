namespace Holcim.Provider.Domain.Models.Proveedor
{
    public class GetResponseProviderRfx
    {
        public Guid IdProveedor { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Correo { get; set; }
        public string? RegistroMercantil { get; set; }

    }
}
