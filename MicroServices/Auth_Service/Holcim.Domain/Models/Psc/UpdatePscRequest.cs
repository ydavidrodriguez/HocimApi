using Holcim.Domain.Models.Moneda;
using System.Collections.Generic;

namespace Holcim.Domain.Models.Psc
{
    public class UpdatePscRequest
    {
        public Guid IdPscs { get; set; }
        public string PscsId { get; set; }
        public string PscsNombre { get; set; }
        public Guid CategoriaPscId { get; set; }
        public Guid GrupoPscId { get; set; }
        public bool Estado { get; set; }
        public List<ColumnaExtraDto>? ColumnasExtras { get; set; }

    }
}
