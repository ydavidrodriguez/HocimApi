using Holcim.Application.DataBase.Rol.Commands.List;
using Holcim.Application.Exception;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class RolController : ControllerBase
    {
       
        [HttpGet("GetListRolAll")]
        public async Task<IActionResult> GetListUserAll(
          [FromServices] IListRolCommandHandler ListRolCommandHandler, [FromQuery]Guid? RolId) 
        {
            return Ok(await ListRolCommandHandler.Execute(RolId));
        }

    }
}
