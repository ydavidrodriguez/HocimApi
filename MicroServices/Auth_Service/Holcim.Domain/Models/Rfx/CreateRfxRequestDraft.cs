using Holcim.Domain.Models.Item;
using Holcim.Domain.Models.Pregunta;

namespace Holcim.Domain.Models.Rfx
{
    public class CreateRfxRequestDraft
    {
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }
        public List<CreateItemRequest>? CreateItemRequest { get; set; }
        public List<CrearPregunta>? CrearPregunta { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public List<Guid>? PaisId { get; set; }
        public Guid? MonedaId { get; set; }
        public Guid? EstadoId { get; set; }
        public List<ArchivoSobre>? ArchivoSobre { get; set; }
        public Guid? UsuarioCreacion { get; set; }
        public List<Guid>? IdEncargadoRfx { get; set; }
        public List<string>? ProveedoresInvitados { get; set; }
        public int? ValorReferencia { get; set; }
        public bool? Prueba { get; set; }
        public string? Sitio { get; set; }
        public string? DireccionEntrega { get; set; }

    }
}
