using AutoMapper;
using Dapper;
using Holcim.AuctionService.Application.Database.Auction.Commands.Invite;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.ItemSubasta;
using Holcim.AuctionService.Domain.Entities.Region;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Domain.Models.Auction;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update;

public class UpdateSubastaCommandHandler : IUpdateSubastaCommandHandler
{
    private readonly IDataBaseService _dataBaseService;
    private readonly IMapper _mapper;
    private readonly IDapperProcedure _dapperProcedure;
    private readonly IInviteProviderCommandHandler _inviteProviderHandler;
    


    public UpdateSubastaCommandHandler(
        IInviteProviderCommandHandler inviteProviderHandler,
        IDapperProcedure dapperProcedure,
        IMapper mapper,
        IDataBaseService dataBaseService
        )
    {
        _inviteProviderHandler = inviteProviderHandler;
        _dapperProcedure = dapperProcedure;
        _mapper = mapper;
        _dataBaseService = dataBaseService;
    }

    public async Task<object> Execute(PostUpdateSubastaRequest request)
    {
        if (_dataBaseService.Subasta.Any(s => s.IdSubasta == request.IdSubasta))
        {
            Domain.Entities.Subasta.Subasta updatedSubasta = _mapper.Map<Domain.Entities.Subasta.Subasta>(request);
            _dataBaseService.Subasta.Update(updatedSubasta);

            if (request.postListItemsRequests != null)
            {
                if (request.postListItemsRequests.Count > 0)
                {
                    var oldSubastaItems = await _dataBaseService.ItemSubasta.Where(i => i.SubastaId == request.IdSubasta).ToListAsync();
                    foreach (var item in oldSubastaItems)
                    {
                        var parametersItem = new DynamicParameters();
                        parametersItem.Add("@IdItem", item.ItemId);

                        var result = _dapperProcedure.UpdateQuery(parametersItem, "POSTDELETEITEMAUCTION");
                    }

                    _dataBaseService.ItemSubasta.RemoveRange(oldSubastaItems);

                    foreach (var ItemnewSubasta in request.postListItemsRequests)
                    {
                        var parametrsItem = new DynamicParameters();
                        parametrsItem.Add("@NombreItem", ItemnewSubasta.Nombre);
                        parametrsItem.Add("@UnidadMedidaId", ItemnewSubasta.UnidadMedidaId);
                        parametrsItem.Add("@Cantidad", ItemnewSubasta.Cantidad);
                        parametrsItem.Add("@ValorUnidad", ItemnewSubasta.valorUnidad);
                        parametrsItem.Add("@MonedaId", request.MonedaId);
                        parametrsItem.Add("@iditemsalida", dbType: System.Data.DbType.Guid, direction: System.Data.ParameterDirection.Output);

                        var result = _dapperProcedure.OutputQuery(parametrsItem, "POSTCREATEITEMSAUCTION", "@iditemsalida");
                        Guid IdItem = JsonConvert.DeserializeObject<Guid>(result);

                        ItemSubasta itemSubasta = new ItemSubasta();

                        itemSubasta.IdItemSubasta = Guid.NewGuid();
                        itemSubasta.SubastaId = request.IdSubasta;
                        itemSubasta.ItemId = IdItem;

                        _dataBaseService.ItemSubasta.Add(itemSubasta);

                    }
                }
            }

            if (request.GRUs != null)
            {
                var regionesSubasta = await _dataBaseService.PaisSubasta.Where(r => r.SubastaId == request.IdSubasta).ToListAsync();
                if (regionesSubasta != null)
                {
                    if (regionesSubasta.Count > 0)
                    {
                        _dataBaseService.PaisSubasta.RemoveRange(regionesSubasta);
                    }
                }

                foreach (var pais in request.GRUs)
                {
                    PaisSubasta regionSubasta = new PaisSubasta();
                    regionSubasta.IdPaisSubasta = Guid.NewGuid();
                    regionSubasta.SubastaId = request.IdSubasta;
                    regionSubasta.IdPais = pais;

                    _dataBaseService.PaisSubasta.Add(regionSubasta);
                }
            }


            if (request.proveedoresInvitados != null)
            {
                var correos = request.proveedoresInvitados;
                InviteProviderRequest inviteProviderRequest = new InviteProviderRequest();
                inviteProviderRequest.AuctionId = request.IdSubasta;
                inviteProviderRequest.ProviderEmails = correos;
                await _inviteProviderHandler.Execute(inviteProviderRequest);
            }
            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status201Created,request, "Subasta actualizada exitosamente.");
        }

        return ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se pudo encontrar la subasta con el Id suministrado.");
    }
}