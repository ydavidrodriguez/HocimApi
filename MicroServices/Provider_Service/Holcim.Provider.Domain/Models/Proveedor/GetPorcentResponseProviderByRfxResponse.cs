namespace Holcim.Provider.Domain.Models.Proveedor
{
    public class GetPorcentResponseProviderByRfxResponse
    {
        public string? NombreEmpresa { get; set; }
        public Guid IdProveedor { get; set; }
        public string? Correo { get; set; }
        public string? Calificacion { get; set; }
        public string? Observacion { get; set; }

    }
}
