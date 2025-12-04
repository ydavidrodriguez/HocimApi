using Holcim.Application.DataBase.Rfx.Commands.Create;
using Holcim.Application.DataBase.Rfx.Commands.Delete;
using Holcim.Application.DataBase.Rfx.Commands.GettraceabilityRfx;
using Holcim.Application.DataBase.Rfx.Commands.List;
using Holcim.Application.DataBase.Rfx.Commands.PostreassignRfxUser;
using Holcim.Application.DataBase.Rfx.Commands.Update;
using Holcim.Application.Exception;
using Holcim.Domain.Models.Proveedor;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    [TypeFilter(typeof(ExceptionManager))]
    public class RfxController : ControllerBase
    {
        [HttpGet("GetListRfxAll")]
        public async Task<IActionResult> GetListRegionAll(
       [FromServices] IListRfxCommandHandler ListRfxCommandHandler, [FromQuery] string? Nombre, [FromQuery] Guid? EstadoId, [FromQuery] bool? Gestion)
        {
            return Ok(await ListRfxCommandHandler.Execute(Nombre, EstadoId, Gestion));
        }

        [HttpPost("PostCreateRfx")]
        public async Task<IActionResult> PostCreateRfx(
        [FromServices] ICreateRfxCommandHandler CreateRfxCommandHandler, [FromBody] CreateRfxRequest createRfxRequest)
        {
            return Ok(await CreateRfxCommandHandler.Execute(createRfxRequest));
        }
        [HttpPost("PostCreateRfxDraft")]
        public async Task<IActionResult> PostCreateRfxDraft(
        [FromServices] ICreateRfxTemplateCommandHandler CreateRfxTemplateCommandHandler, [FromBody] CreateRfxRequestDraft createRfxRequestDraft)
        {
            return Ok(await CreateRfxTemplateCommandHandler.Execute(createRfxRequestDraft));
        }
        [HttpPut("PostEditRfxDraft")]
        public async Task<IActionResult> PostEditRfxDraft(
        [FromServices] IPostEditRfxDraftCommandHandler PostEditRfxDraftCommandHandler, [FromBody] UpdateRfxRequestDraft updateRfxRequestDraft)
        {
            return Ok(await PostEditRfxDraftCommandHandler.Execute(updateRfxRequestDraft));
        }
        [HttpDelete("DeleteRfxDraft")]
        public async Task<IActionResult> DeleteRfxDraft(
        [FromServices] IDeleteRfxTemplateCommandHandler deleteRfxTemplateCommandHandler, [FromQuery] Guid idRfxTemporal)
        {
            return Ok(await deleteRfxTemplateCommandHandler.Execute(idRfxTemporal));
        }
        [HttpGet("GetListRfxDraft")]
        public async Task<IActionResult> GetListRfxDraft(
        [FromServices] IGetListRfxDraftCommandHandle ListRfxCommandHandler, [FromQuery] string? Nombre)
        {
            return Ok(await ListRfxCommandHandler.Execute(Nombre));
        }

        [HttpPut("PutUpdateRfx")]
        public async Task<IActionResult> PutUpdateRegion(
        [FromServices] IUpdateRfxCommandHandler UpdateRfxCommandHandler, [FromBody] UpdateRfxRequest updateRfxRequest)
        {
            var data = await UpdateRfxCommandHandler.Execute(updateRfxRequest);
            return Ok(data);
        }
        [HttpGet("GetListRfxById")]
        public async Task<IActionResult> GetListRegionById(
        [FromServices] IListRfxByIdCommandHandler ListRfxByIdCommandHandler, [FromQuery] Guid idrfx)
        {
            return Ok(await ListRfxByIdCommandHandler.Execute(idrfx));
        }
        [HttpPut("PutUpdateStateRfxbyId")]
        public async Task<IActionResult> PutUpdateStateRfxbyId(
        [FromServices] IUpdateStateRfxCommandHandler UpdateStateRfxCommandHandler, [FromBody] RfxTrazabilidadRequest rfxTrazabilidadRequest)
        {
            return Ok(await UpdateStateRfxCommandHandler.Execute(rfxTrazabilidadRequest));
        }
        [HttpPost("PostreassignRfxUser")]
        public async Task<IActionResult> PostreassignRfxUser(
        [FromServices] IPostreassignRfxUserCommandHandler PostreassignRfxUserCommandHandler, [FromBody] PostreassignRfxUserRequest postreassignRfxUserRequest)
        {
            return Ok(await PostreassignRfxUserCommandHandler.Execute(postreassignRfxUserRequest));
        }
        [HttpGet("GettraceabilityRfx")]
        public async Task<IActionResult> GettraceabilityRfx(
        [FromServices] IGettraceabilityRfx GettraceabilityRfx, [FromQuery] Guid IdRfx)
        {
            return Ok(await GettraceabilityRfx.Execute(IdRfx));
        }

        [HttpGet("GetlistRfxStateAprobado")]
        public async Task<IActionResult> GetlistRfxStateAprobado(
        [FromServices] IGetlistRfxStateAprobadoCommadHandler GetlistRfxStateAprobadoCommadHandler, [FromQuery] Guid IdUsuario)
        {
            return Ok(await GetlistRfxStateAprobadoCommadHandler.Execute(IdUsuario));
        }
        [HttpGet("GetListRfxByUserCommandHandler")]
        public async Task<IActionResult> GetListRfxByUserCommandHandler(
        [FromServices] IGetListRfxByUserCommandHandler GetListRfxByUserCommandHandler, [FromQuery] Guid IdUsuario)
        {
            return Ok(await GetListRfxByUserCommandHandler.Execute(IdUsuario));

        }
        [HttpPost("PostAdjudicarProveedorRfx")]
        public async Task<IActionResult> PostAdjudicarProveedorRfx(
        [FromServices] IPostCreateAdjudicarRfxCommandHandler postCreateGanadorRfxCommandHandler, [FromBody] List<PostCreateProveedorAdjudicar> PostCreateProveedorAdjudicar)
        {
            return Ok(await postCreateGanadorRfxCommandHandler.Execute(PostCreateProveedorAdjudicar));
        }
        [HttpPost("DeleteAdjudicarProveedorRfx")]
        public async Task<IActionResult> DeleteAdjudicarProveedorRfx(
       [FromServices] IPostDeleteAdjudicarProveedorCommandHandler PostDeleteAdjudicarProveedorCommandHandler,
       [FromBody] PostDeleteProveedorAdjudicar postDeleteProveedorAdjudicar)
        {
            return Ok(await PostDeleteAdjudicarProveedorCommandHandler.Execute(postDeleteProveedorAdjudicar));
        }
        [HttpGet("GetListAdjudicarProveedorRfxCommandHandler")]
        public async Task<IActionResult> GetListAdjudicarProveedorRfxCommandHandler(
        [FromServices] IGetListAdjudicarProveedorRfxCommandHandler GetListAdjudicarProveedorRfxCommandHandler, [FromQuery] Guid IdRfx)
        {
            return Ok(await GetListAdjudicarProveedorRfxCommandHandler.Execute(IdRfx));

        }
        [HttpPut("PutUpdatePathRfxCommandHandler")]
        public async Task<IActionResult> PutUpdatePathRfxCommandHandler(
        [FromServices] IPutUpdatePathRfxCommandHandler PutUpdatePathRfxCommandHandler, 
        [FromBody] UpdatePathRfxRequest UpdatePathRfxRequest)
        {
            return Ok(await PutUpdatePathRfxCommandHandler.Execute(UpdatePathRfxRequest ));

        }


    }
}

