using Holcim.Application.DataBase.Psc.Categorias.List;
using Holcim.Application.DataBase.Psc.Commands.Create;
using Holcim.Application.DataBase.Psc.Commands.GetById;
using Holcim.Application.DataBase.Psc.Commands.List;
using Holcim.Application.DataBase.Psc.Commands.Update;
using Holcim.Application.DataBase.Psc.Grupo.List;
using Holcim.Application.Exception;
using Holcim.Domain.Models.Psc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PscController : ControllerBase
    {
        [HttpGet("GetListPscAll")]
        public async Task<IActionResult> GetListPscAll(
        [FromServices] IGetListPscCommandHandler GetListPscCommandHandler, [FromQuery] string? Codigo)
        {
            return Ok(await GetListPscCommandHandler.Execute(Codigo));

        }

        [HttpPut("PutUpdatePsc")]
        public async Task<IActionResult> PutUpdatePsc(
        [FromServices] IUpdatePscCommandHandler UpdatePscCommandHandler, [FromBody] UpdatePscRequest updatePscRequest)
        {
            return Ok(await UpdatePscCommandHandler.Execute(updatePscRequest));
        }

        [HttpPost("PostCreatePsc")]
        public async Task<IActionResult> PostCreatePsc(
        [FromServices] ICreatePscCommandHandler CreatePscCommandHandler, [FromBody] List<CreatePscRequest> createPscRequest)
        {
            return Ok(await CreatePscCommandHandler.Execute(createPscRequest));

        }

        [HttpGet("GetPscById")]
        public async Task<IActionResult> GetPscById(
        [FromServices] IGetListPscByIdCommandHandler GetListPscByIdCommandHandler, [FromQuery] Guid IdPsc)
        {
            return Ok(await GetListPscByIdCommandHandler.Execute(IdPsc));
        }

        [HttpGet("GetListPscCategoria")]
        public async Task<IActionResult> GetListPscCategoria(
        [FromServices] IGetListCategoriaPscCommandHandler GetListCategoriaPscCommandHandle)
        {
            return Ok(await GetListCategoriaPscCommandHandle.Execute());
        }

        [HttpGet("GetListPscGrupo")]
        public async Task<IActionResult> GetListPscGrupo(
        [FromServices] IGetListGrupoPscCommandHandler GetListGrupoPscCommandHandler)
        {
            return Ok(await GetListGrupoPscCommandHandler.Execute());
        }

    }
}
