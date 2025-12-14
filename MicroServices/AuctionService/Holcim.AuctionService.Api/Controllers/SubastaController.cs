using Holcim.AuctionService.Application.Database.Auction.Commands.GetById;
using Holcim.AuctionService.Application.Database.Auction.Commands.Invite;
using Holcim.AuctionService.Application.Database.Auction.Commands.List;
using Holcim.AuctionService.Application.Database.Subasta.Command.Actualizar;
using Holcim.AuctionService.Application.Database.Subasta.Command.Create;
using Holcim.AuctionService.Application.Database.Subasta.Command.Delete;
using Holcim.AuctionService.Application.Database.Subasta.Command.List;
using Holcim.AuctionService.Application.Database.Subasta.Command.Update;
using Holcim.AuctionService.Application.Database.TipoSubasta.Commands;
using Holcim.AuctionService.Application.Database.Trazabilidad.Commands;
using Holcim.AuctionService.Application.Exception;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Domain.Models.Auction;
using Holcim.AuctionService.Domain.Models.Subasta;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.AuctionService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class SubastaController : ControllerBase
    {

        [HttpPut("putActualizarEstadoSubasta")]
        public async Task<IActionResult> putActualizarEstadoSubasta(
            [FromServices] IActualizarEstadoSubastaCommandHandler actualizarEstadoSubastaCommandHandler,
            [FromBody] ActualizarEstadoBaseRequest request)
        {

            return Ok(await actualizarEstadoSubastaCommandHandler.Execute(request));
        }

        [HttpPost("PostCreateSubasta")]
        public async Task<IActionResult> PostCreateSubasta(
        [FromServices] ICreateSubastaCommandHandler CreateSubastaCommandHandler, [FromBody] PostCreateSubastaRequest postCreateSubastaRequest)
        {
            return Ok(await CreateSubastaCommandHandler.Execute(postCreateSubastaRequest));
        }

        [HttpPost("PostCreateSubastaDraft")]
        public async Task<IActionResult> PostCreateSubastaDraft(
        [FromServices] ICreateSubastaTemplateCommandHandler CreateSubastaTemplateCommandHandler, [FromBody] PostCreateSubastaRequest createSubastaRequestDraft)
        {
            return Ok(await CreateSubastaTemplateCommandHandler.Execute(createSubastaRequestDraft));
        }

        [HttpPost("PostUpdateSubasta")]
        public async Task<IActionResult> PostUpdateSubasta(
            [FromServices] IUpdateSubastaCommandHandler UpdateSubastaCommandHandler, [FromBody] PostUpdateSubastaRequest request)
        {
            return Ok(await UpdateSubastaCommandHandler.Execute(request));
        }
        [HttpPut("UpdateConfiguracionSubasta")]
        public async Task<IActionResult> PostUpdateSubasta(
            [FromServices] IUpdateConfiguracionCommandHandler UpdateConfiguracionCommandHandler,
            [FromBody] PostUpdateConfiguracionRequest request)
        {
            return Ok(UpdateConfiguracionCommandHandler.Execute(request));
        }
        [HttpPost("PostCreateOffer")]
        public async Task<IActionResult> PostCreateOffer(
            [FromServices] ICreateOfferCommandHandler createOfferCommandHandler,
            [FromBody] PostCreateOfferRequest request)
        {
            return Ok(await createOfferCommandHandler.Execute(request));
        }

        [HttpGet("GetOffertByAuctionId")]
        public async Task<IActionResult> GetAuctionById(
            [FromServices] IGetOffertByAuctionIdCommandHandler getOffertByAuctionIdCommandHandler,
            [FromQuery] Guid auctionId, [FromQuery] Guid? userId)
        {
            return Ok(await getOffertByAuctionIdCommandHandler.Execute(auctionId, userId));
        }

        [HttpDelete("DeleteOferta")]
        public async Task<IActionResult> DeleteOferta(
          [FromServices] IDeleteOfertaSubastaCommandHandler deleteOfertaSubastaCommandHandler,
          [FromQuery] Guid idOfertaSubasta)
        {
            return Ok(await deleteOfertaSubastaCommandHandler.Execute(idOfertaSubasta));
        }

        [HttpGet("GetAllAuctions")]
        public async Task<IActionResult> GetAllAuctions(
            [FromServices] IListAuctionsCommandHandler listAuctionsHandler, [FromQuery] string? Nombre, [FromQuery] Guid? IdSubasta)
        {
            return Ok(await listAuctionsHandler.Execute(Nombre, IdSubasta));
        }

        [HttpGet("GetAuctionById")]
        public async Task<IActionResult> GetAuctionById(
            [FromServices] IGetAuctionByIdCommandHandler getAuctionByIdHandler,
            [FromQuery] Guid auctionId, [FromQuery] Guid usuarioId)
        {
            return Ok(await getAuctionByIdHandler.Execute(auctionId, usuarioId));
        }

        [HttpGet("GetAuctionByIdAndUserId")]
        public async Task<IActionResult> GetAuctionByIdAndUserId(
            [FromServices] IGetAuctionByIdCommandHandler getAuctionByIdHandler,
            [FromQuery] Guid auctionId, [FromQuery] Guid usuarioId)
        {
            return Ok(await getAuctionByIdHandler.Execute(auctionId, usuarioId));
        }

        [HttpGet("GetAuctionsByProviderId")]
        public async Task<IActionResult> GetAuctioGetAuctionsByProviderIdnById(
            [FromServices] IGetAuctionByProviderIdCommandHandler getAuctionByProviderIdCommandHandler,
            [FromQuery] Guid userId)
        {
            return Ok(await getAuctionByProviderIdCommandHandler.Execute(userId));
        }

        [HttpPost("InviteProviders")]
        public async Task<IActionResult> InviteProviders(
            [FromServices] IInviteProviderCommandHandler inviteProviderHandler,
            [FromBody] InviteProviderRequest request)
        {
            var result = await inviteProviderHandler.Execute(request);
            return Ok(result);
        }

        [HttpGet("AuctionTypes")]
        public IActionResult GetAuctionTypes(
            [FromServices] IGetTipoSubastaCommandHandler getTipoSubastaCommandHandler
        )
        {
            var result = getTipoSubastaCommandHandler.Execute();
            return Ok(result);
        }
        [HttpGet("getLogsSubasta")]
        public async Task<IActionResult> GetAuctionLogs(
            [FromServices] IGetLogsSubastaCommandHandler getLogsSubastaCommandHandler,
            [FromQuery] Guid auctionId
        )
        {
            return Ok(await getLogsSubastaCommandHandler.Execute(auctionId));
        }

        [HttpPut("putReassignAuctionUser")]
        public async Task<IActionResult> putReasignarSubasta(
            [FromServices] IReasignarSubastaCommandHandler actualizarEstadoSubastaCommandHandler,
            [FromBody] PutReasignarSubastaRequest request)
        {
            return Ok(await actualizarEstadoSubastaCommandHandler.Execute(request));
        }
        [HttpPut("putAgregarTiempoSubasta")]
        public async Task<IActionResult> putAgregarTiempoSubasta(
            [FromServices] IAgregarTiempoSubastaCommandHandler agregarTiempoSubastaCommandHandler,
            [FromBody] PatchAgregarTiempoSubastaRequest request)
        {
            return Ok(await agregarTiempoSubastaCommandHandler.Execute(request));
        }
        [HttpPut("PutUpdateColaborators")]
        public async Task<IActionResult> PutUpdateColaborators(
            [FromServices] IPutUpdateColaboratorsCommandHandler putUpdateColaboratorsCommandHandler,
            [FromBody] PutUpdateColaboratorsRequest request)
        {
            return Ok(await putUpdateColaboratorsCommandHandler.Execute(request));
        }
        [HttpPut("PutUpdatePathSubastaCommandHandler")]
        public async Task<IActionResult> PutUpdatePathSubasta(
            [FromServices] IPutSubastaUpdatePathCommandHandler putSubastaUpdatePathCommandHandler,
            [FromBody] UpdatePathSubastaRequest request
            )
        {
            return Ok(await putSubastaUpdatePathCommandHandler.Execute(request));   
        }
        [HttpPost("DeleteOtorgado")]
        public async Task<IActionResult> DeleteOtorgado(
          [FromServices] IDeleteAdjudicarSubastaCommandHandle deleteAdjudicarSubastaCommandHandle,
          [FromBody] DeleteOtorgadoRequest DeleteOtorgadoRequest)
        {
            return Ok(await deleteAdjudicarSubastaCommandHandle.Execute(DeleteOtorgadoRequest));
        }

        [HttpPost("CreateOtorgado")]
        public async Task<IActionResult> DeleteOtorgado(
          [FromServices] ICreateAdjudicarSubastaCommandHandler createAdjudicarSubastaCommandHandler,
          [FromBody] PostOtorgarSubasta postOtorgarSubasta)
        {
            return Ok(await createAdjudicarSubastaCommandHandler.Execute(postOtorgarSubasta));
        }

        [HttpPost("CreateListOtorgado")]
        public async Task<IActionResult> CreateListOtorgado(
          [FromServices] ICreateListAdjudicarSubastaCommandHandler createListAdjudicarSubastaCommandHandler,
          [FromBody] List<PostOtorgarSubasta> postOtorgarSubasta)
        {
            return Ok(await createListAdjudicarSubastaCommandHandler.Execute(postOtorgarSubasta));
        }

        [HttpPut("UpdateFechaPausaSubasta")]
        public async Task<IActionResult> UpdateFechaPausaSubasta(
         [FromServices] IUpdateFechaPausaSubastaCommandHandler updateFechaPausaSubastaCommandHandler,
         [FromBody] PutSubastaFechaPausaRequest putSubastaFechaPausaRequest)
        {
            return Ok(await updateFechaPausaSubastaCommandHandler.Execute(putSubastaFechaPausaRequest));
        } 
        
        [HttpPut("UpdateFechaReanudarSubasta")]
        public async Task<IActionResult> UpdateFechaPausaSubasta(
         [FromServices] IUpdateReanudarSubastaCommandHandler UpdateReanudarSubastaCommandHandler,
         [FromBody] PutSubastaFechaPausaRequest putSubastaFechaPausaRequest)
        {
            return Ok(await UpdateReanudarSubastaCommandHandler.Execute(putSubastaFechaPausaRequest));
        }

        [HttpGet("ListOtorgadoBySubastaId")]
        public async Task<IActionResult> ListOtorgadoBySubastaId(
         [FromServices] IIistBySubastaIdCommandHandler ListBySubastaIdCommandHandler,
         [FromQuery] Guid SuabstaId)
        {
            return Ok(await ListBySubastaIdCommandHandler.Execute(SuabstaId));
        }
       
    }
}
