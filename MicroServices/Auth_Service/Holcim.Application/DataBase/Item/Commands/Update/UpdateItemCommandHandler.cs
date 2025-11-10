using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Item;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Item.Commands.Update
{
    public class UpdateItemCommandHandler : IUpdateItemCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;



        public UpdateItemCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute(ItemDetalle itemdetalle)
        {
            Domain.Entities.Item.Item EntiteItem = _dataBaseService.Item.Where(x => x.IdItem == itemdetalle.Item.IdItem).FirstOrDefault();
            ItemDetalle itemDetalleEntity = _dataBaseService.ItemDetalle.Where(x => x.ItemId == EntiteItem.IdItem).FirstOrDefault();
            if (EntiteItem == null)
            {
                EntiteItem.Nombre = itemdetalle.Item.Nombre;
                EntiteItem.Estado = itemdetalle.Item.Estado;

                itemDetalleEntity.PscsId = itemdetalle.PscsId;
                itemDetalleEntity.Cantidad = itemdetalle.Cantidad;
                itemDetalleEntity.UnidadMedidaId = itemdetalle.UnidadMedidaId;
                itemDetalleEntity.Observacion = itemdetalle.Observacion;
                itemDetalleEntity.VisualizacionPrecioProveedor = itemdetalle.VisualizacionPrecioProveedor;


                _dataBaseService.Item.Update(EntiteItem);
                _dataBaseService.ItemDetalle.Update(itemDetalleEntity);
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Items Actulizado Correctamente");

        }


    }
}
