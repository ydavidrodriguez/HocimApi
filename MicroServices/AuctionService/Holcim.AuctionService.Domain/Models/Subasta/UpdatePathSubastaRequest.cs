using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.AuctionService.Domain.Models.Subasta
{
   public class UpdatePathSubastaRequest
    {
        public Guid IdSubasta { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}
