using Holcim.AuctionService.Application.Database.Ronda.Commands.Get;
using Holcim.AuctionService.Application.Database.Subasta.Command.Create;
using Holcim.AuctionService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.AuctionService.Api.Controllers
{
    public class RondaController : ControllerBase
    {
        [HttpPost("PostCreateSubasta")]
        public async Task<IActionResult> PostCreateSubasta(
        [FromServices] ICreateSubastaCommandHandler CreateSubastaCommandHandler, [FromBody] PostCreateSubastaRequest postCreateSubastaRequest)
        {
            return Ok(await CreateSubastaCommandHandler.Execute(postCreateSubastaRequest));
        }

        [HttpGet("GetLastRoundItems")]
        public async Task<IActionResult> GetLastRoundItems(
            [FromServices] IGetLastRoundItemsCommandHandler GetLastRoundItemsCommandHandler,
            [FromQuery] Guid auctionId)
        {
            return Ok(await GetLastRoundItemsCommandHandler.Execute(auctionId));
        }
    }
}
