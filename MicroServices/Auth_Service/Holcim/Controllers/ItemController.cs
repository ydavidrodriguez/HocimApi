using Holcim.Application.DataBase.Item.Commands.Create;
using Holcim.Application.DataBase.Item.Commands.List;
using Holcim.Application.Exception;
using Holcim.Domain.Models.Item;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ItemController : ControllerBase
    {
        [HttpPost("PostCreateItem")]
        public async Task<IActionResult> PostCreateItem(
        [FromServices] ICreateItemCommandHandler createItemCommandHandler, [FromBody] List<CreateItemRequest> 
            createItems)
        {
            return Ok(await createItemCommandHandler.Execute(createItems, null, null));
        }
        [HttpGet("GetListItem")]
        public async Task<IActionResult> GetListItem(
        [FromServices] IListItemCommandHandler ListItemCommandHandler, [FromQuery] Guid
           Itemid)
        {
            return Ok(await ListItemCommandHandler.Execute(Itemid));
        }
    }
}
