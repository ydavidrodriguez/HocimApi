using Holcim.Domain.Models.Moneda;
using System.Collections.Generic;

namespace Holcim.Domain.Models.UnidadMedida
{
    public class CreateUnidadMedidaRequest
    {
        public string UdmCode { get; set; }
        public string UdmDescripcion { get; set; }
        public List<ColumnaExtraDto>? ColumnasExtras { get; set; }

    }
}
