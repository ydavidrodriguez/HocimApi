using Holcim.Domain.Models.Moneda;
using System.Collections.Generic;

namespace Holcim.Domain.Entities.Pscs
{
    public class GrupoPsc
    {
        public Guid IdGrupoPsc { get; set; }
        public string Nombre { get; set; }
        public List<ColumnaExtraDto>? ColumnasExtras { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}
