using Holcim.Application.DataBase.Correo.Commands;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.Estado;
using Holcim.AuctionService.Domain.Entities.ProveedorSubasta;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Holcim.AuctionService.Domain.Enums;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Domain.Models.Auction;
using Holcim.AuctionService.Domain.Models.Correo;
using Holcim.AuctionService.Domain.Models.Subasta;
using Holcim.AuctionService.Domain.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Auction.Commands.Invite
{
    public class InviteProviderCommandHandler : IInviteProviderCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly ICreateCorreoCommandHandler _createCorreoCommandHandler;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public InviteProviderCommandHandler(
            IDataBaseService dataBaseService,
            ICreateCorreoCommandHandler createCorreoCommandHandler,
            IDapperProcedure dapperProcedure,IHttpClientFactory httpClientFactory,IHttpContextAccessor httpContextAccessor)
        {
            _dataBaseService = dataBaseService;
            _createCorreoCommandHandler = createCorreoCommandHandler;
            _dapperProcedure = dapperProcedure;
            _httpClientFactory = httpClientFactory; 
            _httpContextAccessor= httpContextAccessor;
        }

        public async Task<object> Execute(InviteProviderRequest inviteProviderRequest)
        {
            var lang = _httpContextAccessor.HttpContext?.Items["lang"] as string ?? "es";
            var idioma = Uri.EscapeDataString(lang);
            var client = _httpClientFactory.CreateClient("ApiGatewayService");
            var auction = await _dataBaseService.Subasta.FindAsync(inviteProviderRequest.AuctionId);
            if (auction == null)
            {
                throw new System.Exception(
                    $"Auction with ID {inviteProviderRequest.AuctionId} not found.");
            }

            var existingProviders = _dataBaseService.ProveedorSubasta
                .Where(ps => ps.SubastaId == inviteProviderRequest.AuctionId)
                .ToList();

            if (existingProviders.Any())
            {
                _dataBaseService.ProveedorSubasta.RemoveRange(existingProviders);
            }

            var existinginvitations = _dataBaseService.InvitacionProveedorSubasta
                .Where(ps => ps.SubastaId == inviteProviderRequest.AuctionId)
                .ToList();

            if (existinginvitations.Any())
            {
                _dataBaseService.InvitacionProveedorSubasta.RemoveRange(existinginvitations);
            }

            var invitacion = new InvitacionProveedorSubasta
            {
                IdInvitacionProveedorSubasta = Guid.NewGuid(),
                Correo = JsonConvert.SerializeObject(inviteProviderRequest.ProviderEmails),
                SubastaId = inviteProviderRequest.AuctionId
            };

            _dataBaseService.InvitacionProveedorSubasta.Add(invitacion);

            if (inviteProviderRequest.ProviderEmails != null)
            {
                foreach (var proveedorEmail in inviteProviderRequest.ProviderEmails)
                {
                    var parametersActionemail = new { Correo = proveedorEmail };
                    var resultitem = _dapperProcedure.GetQuery(parametersActionemail, "GETPROVIDERAUCTIONEMAIL");
                    var getProveedorResponse = JsonConvert.DeserializeObject<List<GetProveedorResponse>>(resultitem);

                    if (getProveedorResponse != null && getProveedorResponse.Count > 0)
                    {
                        var proveedorId = getProveedorResponse[0].IdProveedor;

                        var proveedorSubasta = new ProveedorSubasta
                        {
                            IdProveedorSubasta = Guid.NewGuid(),
                            ProveedorId = proveedorId,
                            SubastaId = inviteProviderRequest.AuctionId
                        };
                        _dataBaseService.ProveedorSubasta.Add(proveedorSubasta);
                    }
                }
            }





            var dbUser = _dataBaseService.Usuario.AsQueryable();
            var usuarioCreacion= await dbUser.Where(a => a.IdUsuario == auction.UsuarioCreacionId).FirstOrDefaultAsync();
            var db = _dataBaseService.ZonaHoraria.AsQueryable();
            var zonaHoraria = await db.Where(a => a.IdZonaHoraria == auction.ZonaHorariaId).FirstOrDefaultAsync();
            var tipoSubasta = await _dataBaseService.TipoSubasta.Where(a=>a.IdTipoSubasta==auction.TipoSubastaId).FirstOrDefaultAsync();
            var replacementsPorProveedor = new Dictionary<string, Dictionary<string, string>>();

            foreach (var proveedorEmail in inviteProviderRequest.ProviderEmails)
            {   
                var proveedor= await dbUser.Where(a=>a.Correo==proveedorEmail).FirstOrDefaultAsync();
                var replacementsInd = new Dictionary<string, string>
                {
                    { "{0}", "Subasta Holcim" },
                    { "{1}", auction.Titulo },
                    { "{2}", auction.FechaInicio.ToString() + " - " + zonaHoraria?.Nombre },
                    { "{3}", tipoSubasta?.Descripcion },
                    { "{4}", usuarioCreacion.Nombre.ToString() },
                    { "{5}", proveedor.Nombre.ToString() },
                    { "{6}", usuarioCreacion.Correo.ToString() }
            };

                replacementsPorProveedor.Add(proveedorEmail, replacementsInd);
            }
            await _createCorreoCommandHandler.Execute(inviteProviderRequest.ProviderEmails, $"Invitación a Subasta: {auction.Titulo}",
                EnumDomain.InvitacionAuction.GetEnumMemberValue().ToString(), replacementsPorProveedor);

            var res = new
            {
                AuctionId = inviteProviderRequest.AuctionId,
                ProvidersInvited = inviteProviderRequest.ProviderEmails
            };
            //await _dataBaseService.SaveAsync();


            return ResponseApiService.Response(
                StatusCodes.Status200OK,
                res,
                "Invitations updated successfully"
            );
        }
    }
}