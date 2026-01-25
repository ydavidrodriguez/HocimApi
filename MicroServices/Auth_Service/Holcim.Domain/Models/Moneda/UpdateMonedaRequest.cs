using System.Collections.Generic;

namespace Holcim.Domain.Models.Moneda
{
    public class UpdateMonedaRequest
    {
        public Guid IdMoneda { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public List<ColumnaExtraDto>? ColumnasExtras { get; set; }

    }
}
