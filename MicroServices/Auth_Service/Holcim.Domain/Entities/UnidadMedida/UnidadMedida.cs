using Holcim.Domain.Models.Moneda;
using System.Collections.Generic;

namespace Holcim.Domain.Entities.UnidadMedida
{
    public class UnidadMedida
    {
        public Guid IdUnidadMedida { get; set; }
        public string? UdmCode { get; set; }
        public string? UdmDescripcion { get; set; }
        public List<ColumnaExtraDto>? ColumnasExtras { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }

    }
}
