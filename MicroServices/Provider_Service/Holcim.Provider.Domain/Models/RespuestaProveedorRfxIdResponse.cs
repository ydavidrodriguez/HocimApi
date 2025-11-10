namespace Holcim.Provider.Domain.Models
{
    public class RespuestaProveedorRfxIdResponse
    {
        public Guid IdProveedor { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Correo { get; set; }
        public string? RegistroMercantil { get; set; }
        public string? Observacion { get; set; }
        public string? Calificacion { get; set; }

    }
}
