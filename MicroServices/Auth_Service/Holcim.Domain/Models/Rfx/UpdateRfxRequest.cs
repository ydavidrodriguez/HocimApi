using Holcim.Domain.Models.Item;
using Holcim.Domain.Models.Pregunta;

namespace Holcim.Domain.Models.Rfx
{
    public class UpdateRfxRequest
    {
        public Guid IdRfx { get; set; }
        public string? Nombre { get; set; }
        public string? Detalle { get; set; }
        public List<UpdateItemRequest> UpdateItemRequest { get; set; }
        public List<CrearPregunta>? CrearPregunta { get; set; }
        public Guid TipoRfxId { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public List<Guid> PaisId { get; set; }
        public Guid MonedaId { get; set; }
        public Guid EstadoId { get; set; }
        public List<UpdateArchivoSobre>? ArchivoSobre { get; set; }
        public Guid UsuarioCreacion { get; set; }
        public List<string>? ProveedoresInvitados { get; set; }
        public long? ValorReferencia { get; set; }


    }
}
