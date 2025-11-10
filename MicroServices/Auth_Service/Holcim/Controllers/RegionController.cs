using Holcim.Application.DataBase.Cargo.Commands.List;
using Holcim.Application.DataBase.Region.Commands.Create;
using Holcim.Application.DataBase.Region.Commands.List;
using Holcim.Application.DataBase.Region.Commands.ListById;
using Holcim.Application.DataBase.Region.Commands.Update;
using Holcim.Application.Exception;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Region;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class RegionController : ControllerBase
    {
        [HttpGet("GetListRegionAll")]
        public async Task<IActionResult> GetListRegionAll(
       [FromServices] IGetListRegionCommandHandler GetListRegionCommandHandler, [FromQuery]string? Nombre )
        {
            var data = await GetListRegionCommandHandler.Execute(Nombre);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPost("PostCreateRegion")]
        public async Task<IActionResult> PostCreateRegion(
        [FromServices] ICreateRegionCommandHandler CreateRegionCommandHandler, [FromBody] CreateRegionRequest createRegionRequest)
        {
            var data = await CreateRegionCommandHandler.Execute(createRegionRequest);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }
        [HttpPut("PutUpdateRegion")]
        public async Task<IActionResult> PutUpdateRegion(
        [FromServices] IUpdateRegionCommandHandler UpdateRegionCommandHandler, [FromBody] UpdateRegionRequest UpdateRegionRequest)
        {
            var data = await UpdateRegionCommandHandler.Execute(UpdateRegionRequest);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }
        [HttpGet("GetListRegionById")]
        public async Task<IActionResult> GetListRegionById(
        [FromServices] IGetListRegionByIdCommandHandler GetListRegionByIdCommandHandler, [FromQuery] Guid IdRegion )
        {
            var data = await GetListRegionByIdCommandHandler.Execute(IdRegion);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

    }
}
