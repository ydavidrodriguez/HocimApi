using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.AuctionService.Domain.Entities.ZonaHoraria
{
    public class ZonaHoraria
    {
        public Guid IdZonaHoraria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }


    }
}
