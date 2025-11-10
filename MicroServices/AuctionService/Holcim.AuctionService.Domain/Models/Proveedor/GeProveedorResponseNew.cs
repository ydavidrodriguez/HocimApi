using Newtonsoft.Json;

namespace Holcim.AuctionService.Domain.Models.Proveedor
{
    public class GeProveedorResponseNew
    {
        [JsonProperty("idProveedor")]
        public Guid IdProveedor { get; set; }

        [JsonProperty("nombreEmpresa")]
        public string NombreEmpresa { get; set; }

        [JsonProperty("idiomaId")]
        public Guid IdiomaId { get; set; }

        [JsonProperty("registroMercantil")]
        public string RegistroMercantil { get; set; }

        [JsonProperty("correo")]
        public string Correo { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("paisId")]
        public Guid PaisId { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }

        [JsonProperty("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonProperty("fechaActulizacion")]
        public DateTime FechaActulizacion { get; set; }

        [JsonProperty("zonaHorariaId")]
        public Guid ZonaHorariaId { get; set; }
    }
}
