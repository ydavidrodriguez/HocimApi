using Holcim.Domain.Models.Moneda;
using System.Collections.Generic;

namespace Holcim.Domain.Models.Pais
{
    public class CreatePaisRequest
    {
        public string Nombre { get; set; }
        public string? Indicativo { get; set; }
        public Guid RegionId { get; set; }
        public Guid ZonaHoraria { get; set; }
        public List<ColumnaExtraDto>? ColumnasExtras { get; set; }

    }
}
