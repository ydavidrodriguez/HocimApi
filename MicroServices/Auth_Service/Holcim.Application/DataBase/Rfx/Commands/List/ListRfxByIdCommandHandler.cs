using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.PreguntaArchivo;
using Holcim.Domain.Entities.ProveedorRfx;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public class ListRfxByIdCommandHandler : IListRfxByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListRfxByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid Id)
        {
              Domain.Entities.Rfx.Rfx RfxEntity = _dataBaseService.Rfx
                  .Include(x => x.Estado)
                 .Include(x => x.Moneda)
                 .Where(x => x.IdRfx == Id).FirstOrDefault();

            List<RfxPais> rfxPais = _dataBaseService.RfxPais
                .Include(x=> x.Pais)
                .Where(x => x.RfxId == Id).ToList();

            List<Domain.Entities.Rfx.RfxItem> listrfxItem = _dataBaseService.RfxItem
                  .Include(x => x.Item)
                  .Where(x => x.RfxId == RfxEntity.IdRfx).ToList();

            RfxResponse rfxResponse = new RfxResponse();

            rfxResponse.Rfx = RfxEntity;

            List<RfxItemResponse> ListrfxItem = new List<RfxItemResponse>();

            foreach (var itemrfx in listrfxItem)
            {
                RfxItemResponse rfxItem = new RfxItemResponse();
                rfxItem.IdItem = itemrfx.ItemId;
                rfxItem.Nombre = itemrfx.Item.Nombre;
                rfxItem.Estado = itemrfx.Item.Estado;
                rfxItem.Index = itemrfx.Item.Index.Value;

                Domain.Entities.Item.ItemDetalle itemDetalle = _dataBaseService.
                    ItemDetalle.Include(x => x.Pscs).Include(x => x.UnidadMedida).Where(x => x.ItemId == itemrfx.ItemId).First();

                rfxItem.Pscs = itemDetalle.Pscs;
                rfxItem.UnidadMedida = itemDetalle.UnidadMedida;
                rfxItem.Cantidad = itemDetalle.Cantidad;
                rfxItem.valorUnidad = itemDetalle.valorUnidad.Value;
                rfxItem.VisibleProveedor = itemDetalle.VisualizacionPrecioProveedor.Value;
                rfxItem.Detalle = itemDetalle.Observacion;

                //Pregunta Items
                List<PreguntaArchivo> ListPregunta = _dataBaseService.ItemPregunta
                    .Include(x => x.preguntaArchivo)
                    .Where(x => x.ItemId == itemrfx.ItemId).Select(x => new PreguntaArchivo
                    {
                        Afirmacion = x.preguntaArchivo.Afirmacion,
                        IdPreguntaArchivo = x.preguntaArchivoId,
                        Pregunta = x.preguntaArchivo.Pregunta,
                        Requerido = x.preguntaArchivo.Requerido,
                        RutaUrl = x.preguntaArchivo.RutaUrl,
                        ValoresArchivo = _dataBaseService.ValoresArchivo.Where(y => y.IdValoresArchivo == x.preguntaArchivo.ValoresArchivoId).First(),
                        ValoresArchivoId = x.preguntaArchivo.ValoresArchivoId,
                        ValoresArchivoJson = x.preguntaArchivo.ValoresArchivoJson


                    }
                    ).ToList();

          

                rfxItem.LispreguntaArchivo = ListPregunta;
                ListrfxItem.Add(rfxItem);
            }

           
            //Pregunta Sobre
            var SobreArchivo = _dataBaseService.PreguntaSobreRfx
                 .Include(x => x.PreguntaArchivo)
                 .Include(x=> x.PreguntaArchivo.ArchivoSobre)
                 .Where(x => x.RfxId == Id).Select(x=> x.PreguntaArchivo.ArchivoSobre).Distinct().ToList();

            List<ListPreguntaSobreRfx> listPreguntaSobreRfxes = new List<ListPreguntaSobreRfx>();

            foreach (var itempreguntasobre in SobreArchivo) 
            {
                 ListPreguntaSobreRfx itemPreguntaSobreRfxes = new ListPreguntaSobreRfx();

                itemPreguntaSobreRfxes.IdArchivo = itempreguntasobre.IdArchivo;
                itemPreguntaSobreRfxes.NombreArchivo = itempreguntasobre.NombreArchivo;

                var preguntas = _dataBaseService.PreguntaArchivo.Include(x=> x.ValoresArchivo)
                    .Where(x=> x.ArchivoSobreId == itempreguntasobre.IdArchivo).ToList();

                itemPreguntaSobreRfxes.PreguntaArchivo = preguntas;

                listPreguntaSobreRfxes.Add(itemPreguntaSobreRfxes);

            }



            //invitacion de proveedores
            List<ProveedorRfx> proveedorRfx =_dataBaseService.ProveedorRfx.Include(x=> x.Proveedor)
                .Where(x => x.RfxId == Id).ToList(); 



            rfxResponse.RfxItem = ListrfxItem;
            rfxResponse.InvitacionProveedorRfx = proveedorRfx;
            rfxResponse.ListGru = rfxPais;
            rfxResponse.PreguntaSobreRfx = listPreguntaSobreRfxes;




            return ResponseApiService.Response(StatusCodes.Status201Created, rfxResponse
               );
        }

    }
}
