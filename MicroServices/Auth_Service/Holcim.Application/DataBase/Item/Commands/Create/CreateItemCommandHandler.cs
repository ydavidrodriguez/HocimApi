using AutoMapper;
using Holcim.Application.DataBase.Pregunta.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Item;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Models.Item;
using Holcim.Domain.Models.Pregunta;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Item.Commands.Create
{
    public class CreateItemCommandHandler : ICreateItemCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly ICreatePreguntaCommandHandler _createPreguntaCommandHandler;


        public CreateItemCommandHandler(IDataBaseService dataBaseService, IMapper mapper,
            ICreatePreguntaCommandHandler createPreguntaCommandHandler, ICreatePreguntaCommandHandler createPreguntaCommandHandler1)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _createPreguntaCommandHandler = createPreguntaCommandHandler;
        }

        public async Task<object> Execute(List<CreateItemRequest> items, Guid? rfxId, List<CrearPregunta>? preguntas)
        {
            foreach (var itemFor in items)
            {
                var item = new Domain.Entities.Item.Item
                {
                    IdItem = Guid.NewGuid(),
                    Estado = true,
                    FechaCreacion = DateTime.Now,
                    FechaActulizacion = DateTime.Now,
                    Nombre = itemFor.Nombre,
                    Index = itemFor.Index
                };
                _dataBaseService.Item.Add(item);

                _dataBaseService.ItemDetalle.Add(new ItemDetalle
                {
                    IdItemDetalle = Guid.NewGuid(),
                    ItemId = item.IdItem,
                    PscsId = itemFor.PscId,
                    Cantidad = itemFor.Cantidad,
                    UnidadMedidaId = itemFor.UnidadMedidaId,
                    valorUnidad = itemFor.ValorUnidad,
                    Observacion = itemFor.Observacion,
                    VisualizacionPrecioProveedor = itemFor.VisualizacionPrecioProveedor,
                    MonedaId = itemFor.MonedaId
                });

                if (rfxId == null)
                {
                    await _dataBaseService.SaveAsync();
                    return ResponseApiService.Response(StatusCodes.Status201Created, item.IdItem);
                }

                if (rfxId != null)
                {
                    _dataBaseService.RfxItem.Add(new RfxItem
                    {
                        IdRfxItem = Guid.NewGuid(),
                        ItemId = item.IdItem,
                        RfxId = rfxId.Value,
                        Estado = true
                    });
                    await _createPreguntaCommandHandler.Execute(preguntas, item.IdItem, rfxId, null);
                }


            }
            return ResponseApiService.Response(StatusCodes.Status201Created, "Items Creados Correctamente");
        }

    }
}
