using Holcim.Domain.Models.Moneda;
using System.Collections.Generic;

namespace Holcim.Domain.Models.Pais
{
    public class UpdatePaisRequest
    {
        public Guid IdPais { get; set; }
        public string? Nombre { get; set; }
        public bool Estado { get; set; }
        public string? Indicativo { get; set; }
        public Guid RegionId { get; set; }
        public List<ColumnaExtraDto>? ColumnasExtras { get; set; }

    }
}
