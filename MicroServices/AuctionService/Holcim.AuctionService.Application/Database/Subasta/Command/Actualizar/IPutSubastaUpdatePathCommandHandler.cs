using Holcim.AuctionService.Domain.Models.Subasta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Actualizar
{
    public interface IPutSubastaUpdatePathCommandHandler
    {
        Task<object> Execute(UpdatePathSubastaRequest UpdatePathRfxRequest);
    }
}
