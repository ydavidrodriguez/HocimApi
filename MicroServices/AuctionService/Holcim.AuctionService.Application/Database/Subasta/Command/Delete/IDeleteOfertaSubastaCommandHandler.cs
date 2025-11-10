using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Delete
{
    public interface IDeleteOfertaSubastaCommandHandler
    {
        Task<object> Execute(Guid idOfertaSubasta);
    }
}
