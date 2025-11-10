using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Item.Commands.Delete
{
    public class DeleteItemCommandHandler : IDeleteItemCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public DeleteItemCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(List<Domain.Entities.Item.Item> Item)
        {
            if (Item != null && Item.Count > 0)
            {
                foreach (var itemdelete in Item)
                {
                    //Obtener las preguntas del item a eliminar
                    var itempregunta = _dataBaseService.ItemPregunta.Where(x => x.ItemId == itemdelete.IdItem).ToList();

                    _dataBaseService.ItemPregunta.RemoveRange(itempregunta);

                    //Elimina la pregunta
                    foreach (var item in itempregunta)
                    {
                        var preguntaitem = _dataBaseService.PreguntaArchivo.Where(x => x.IdPreguntaArchivo == item.preguntaArchivoId).FirstOrDefault();
                        if (preguntaitem != null)
                            _dataBaseService.PreguntaArchivo.Remove(preguntaitem);
                    }

                    //eliminar en itemrfx

                    var itemrfx = _dataBaseService.RfxItem.Where(x => x.ItemId == itemdelete.IdItem).FirstOrDefault();
                    if (itemrfx != null)
                        _dataBaseService.RfxItem.Remove(itemrfx);

                    var itemdetalle = _dataBaseService.ItemDetalle.Where(x => x.ItemId == itemdelete.IdItem).FirstOrDefault();
                    if (itemdetalle != null)
                        _dataBaseService.ItemDetalle.Remove(itemdetalle);

                    var itemdrop = _dataBaseService.Item.Where(x => x.IdItem == itemdelete.IdItem).FirstOrDefault();
                    if (itemdrop != null)
                        _dataBaseService.Item.Remove(itemdrop);

                }

            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Items Eliminados Correctamente");

        }

    }
}
