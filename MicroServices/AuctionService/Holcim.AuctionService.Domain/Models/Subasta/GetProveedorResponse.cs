namespace Holcim.AuctionService.Domain.Models.Subasta
{
    public class GetProveedorResponse
    {
        public Guid IdProveedor { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Correo { get; set; }
        public string? RegistroMercantil { get; set; }
        public Guid UsuarioId { get; set; }

    }
}
