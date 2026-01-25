using Holcim.Application.DataBase.Pais.Commands.Create;
using Holcim.Application.DataBase.Pais.Commands.List;
using Holcim.Application.DataBase.Pais.Commands.Update;
using Holcim.Application.DataBase.Proveedor.Commands.List;
using Holcim.Application.Exception;
using Holcim.Domain.Models.Pais;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    [TypeFilter(typeof(ExceptionManager))]
    public class PaisController : ControllerBase
    {
        [HttpGet("GetListPaisAll")]
        public async Task<IActionResult> GetListPaisAll(
           [FromServices] IListPaisCommandHandler ListPaisCommandHandler, [FromQuery] string? nombre)
        {
            return Ok(await ListPaisCommandHandler.Execute(nombre, HttpContext.Request.Query["lang"].ToString()));

        }
        [HttpGet("GetListPaisAllGru")]
        public async Task<IActionResult> GetListPaisAllGru(
        [FromServices] IGetListPaisAllGruCommandHandler getListPaisAllGruCommandHandler)
        {
            return Ok(await getListPaisAllGruCommandHandler.Execute(HttpContext.Request.Query["lang"].ToString()));

        }
        [HttpPost("PostCreatePais")]
        public async Task<IActionResult> PostCreatePais(
        [FromServices] ICreatePaisCommandHandler CreatePaisCommandHandler, [FromBody] List<CreatePaisRequest> createPaisRequest)
        {
            return Ok(await CreatePaisCommandHandler.Execute(createPaisRequest));

        }
        [HttpPut("PutUpdatePais")]
        public async Task<IActionResult> PutUpdatePais(
        [FromServices] IUpdatePaisCommandHandler UpdatePaisCommandHandler, [FromBody] UpdatePaisRequest updatePaisRequest)
        {
            return Ok(await UpdatePaisCommandHandler.Execute(updatePaisRequest));
        }
        [HttpGet("GetListPaisById")]
        public async Task<IActionResult> GetListPaisById(
          [FromServices] IListPaisByIdCommandHandler listPaisByIdCommandHandler, [FromQuery] Guid IdPais)
        {
            return Ok(await listPaisByIdCommandHandler.Execute(IdPais));
        }
        [AllowAnonymous]
        [HttpGet("GetListPaisByZonaHorariaId")]
        public async Task<IActionResult> GetListPaisByZonaHorariaId(
         [FromServices] IListPaisByZonaHorariaByIdCommandHandler ListPaisByZonaHorariaByIdCommandHandler, [FromQuery] Guid IdPais)
        {
            return Ok(await ListPaisByZonaHorariaByIdCommandHandler.Execute(IdPais));

        }




    }
}
