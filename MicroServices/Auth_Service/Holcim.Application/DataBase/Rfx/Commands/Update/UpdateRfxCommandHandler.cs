using AutoMapper;
using Holcim.Application.DataBase.Item.Commands.Create;
using Holcim.Application.DataBase.Item.Commands.Delete;
using Holcim.Application.DataBase.Item.Commands.Update;
using Holcim.Application.DataBase.Pais.Commands.Create;
using Holcim.Application.DataBase.Pregunta.Commands.Create;
using Holcim.Application.DataBase.Pregunta.Commands.Delete;
using Holcim.Application.DataBase.Pregunta.Commands.Update;
using Holcim.Application.DataBase.Sobre.Commands.Create;
using Holcim.Application.DataBase.Sobre.Commands.Delete;
using Holcim.Application.DataBase.Sobre.Commands.Update;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Archivos;
using Holcim.Domain.Entities.PreguntaArchivo;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Models.Archivo;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Rfx.Commands.Update
{
    public class UpdateRfxCommandHandler : IUpdateRfxCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly ICreatePreguntaCommandHandler _createPreguntaCommandHandler;
        private readonly IUpdateItemCommandHandler _updateItemCommandHandler;
        private readonly IUpdatePreguntaCommandHandler _updatePreguntaCommandHandler;
        private readonly ICreateRfxPaisCommandHandler _createPaisCommandHandler;
        private readonly IDeleteItemCommandHandler _deleteItemCommandHandler;
        private readonly ICreateItemCommandHandler _createItemCommandHandler;
        private readonly IDeleteSobreCommandHandler _deleteSobreCommandHandler;
        private readonly ICreateSobreCommandHandler _createSobreCommandHandler;
        private readonly IUpdateSobreCommandHandler _updateSobreCommandHandler;
        private readonly IDeletePreguntaCommandHandler _deletePreguntaCommandHandler;

        public UpdateRfxCommandHandler(IDataBaseService dataBaseService, IMapper mapper,
            ICreatePreguntaCommandHandler createPreguntaCommandHandler, IUpdateItemCommandHandler updateItemCommandHandler,
            IUpdatePreguntaCommandHandler updatePreguntaCommandHandler,
            ICreateRfxPaisCommandHandler createPaisCommandHandler,
            IDeleteItemCommandHandler deleteItemCommandHandler,
            ICreateItemCommandHandler createItemCommandHandler,
            IDeleteSobreCommandHandler deleteSobreCommandHandler,
            ICreateSobreCommandHandler createSobreCommandHandler,
            IUpdateSobreCommandHandler updateSobreCommandHandler,
            IDeletePreguntaCommandHandler deletePreguntaCommandHandler
            )
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _createPreguntaCommandHandler = createPreguntaCommandHandler;
            _updateItemCommandHandler = updateItemCommandHandler;
            _updatePreguntaCommandHandler = updatePreguntaCommandHandler;
            _createPaisCommandHandler = createPaisCommandHandler;
            _deleteItemCommandHandler = deleteItemCommandHandler;
            _createItemCommandHandler = createItemCommandHandler;
            _deleteSobreCommandHandler = deleteSobreCommandHandler;
            _createSobreCommandHandler = createSobreCommandHandler;
            _updateSobreCommandHandler = updateSobreCommandHandler;
            _createSobreCommandHandler = createSobreCommandHandler;
            _deletePreguntaCommandHandler = deletePreguntaCommandHandler;
        }
        public async Task<object> Execute(UpdateRfxRequest updateRfxRequest)
        {
            Domain.Entities.Rfx.Rfx rfx = _dataBaseService.Rfx.Where(x => x.IdRfx == updateRfxRequest.IdRfx).FirstOrDefault();
            if (rfx != null)
            {
                rfx.FechaActulizacion = DateTime.Now;
                rfx.EstadoId = updateRfxRequest.EstadoId;
                rfx.Detalle = updateRfxRequest.Detalle;
                rfx.UsuarioCreacion = updateRfxRequest.UsuarioCreacion;
                rfx.FechaInicial = updateRfxRequest.FechaInicial;
                rfx.FechaFinal = updateRfxRequest.FechaFinal;
                rfx.MonedaId = updateRfxRequest.MonedaId;
                rfx.ValorReferencia = updateRfxRequest.ValorReferencia;
                rfx.Nombre = updateRfxRequest.Nombre;
                rfx.TipoRfxId = updateRfxRequest.TipoRfxId;

                _dataBaseService.Rfx.Update(rfx);


                //paises que contiene el rfx 

                List<RfxPais> RfxPaisToRemove =
                      _dataBaseService.RfxPais
                      .Where(x => !updateRfxRequest.PaisId.Contains(x.PaisId)
                      && x.RfxId == updateRfxRequest.IdRfx).ToList();

                //Eliminar los gru que ya no deben estar asociados
                _dataBaseService.RfxPais.RemoveRange(RfxPaisToRemove);

                //Crea los Gru nuevos 
                await _createPaisCommandHandler.Execute(updateRfxRequest.PaisId, rfx.IdRfx);


                //Elimar los items quitados

                var updateitem = updateRfxRequest.UpdateItemRequest.Where(x => x.IdItem != Guid.Empty).Select(y => y.IdItem).ToList();
                if (updateitem.Any())
                {

                    List<Domain.Entities.Item.Item> ItemToDelete = _dataBaseService.RfxItem
                        .Include(x => x.Item)
                        .Include(x => x.Rfx)
                        .Where(x => !updateitem.Contains(x.ItemId) && x.RfxId == rfx.IdRfx).Select(x => x.Item).ToList();

                    //Eliminar Item
                    await _deleteItemCommandHandler.Execute(ItemToDelete);


                    List<Domain.Entities.Item.Item> itemsToUpdate = _dataBaseService.RfxItem
                      .Include(x => x.Item)
                      .Include(x => x.Rfx)
                      .Where(x => updateitem.Contains(x.ItemId) && x.RfxId == rfx.IdRfx).Select(x => x.Item).ToList();

                    //Actualizar

                    if (itemsToUpdate.Any())
                    {
                        foreach (var item in itemsToUpdate)
                        {
                            //Actulizar Item
                            await _updateItemCommandHandler.Execute(_dataBaseService.ItemDetalle.FirstOrDefault(x => x.ItemId == item.IdItem));
                            var questionsToUpdate = updateRfxRequest.CrearPregunta.Where(x => x.PreguntaArchivoId != Guid.Empty).ToList();
                            if (questionsToUpdate.Any())
                            {
                                var questionEntities = _mapper.Map<List<PreguntaArchivo>>(questionsToUpdate);
                                await _updatePreguntaCommandHandler.Execute(questionEntities, item.IdItem);

                            }
                            var questionsToCreate = updateRfxRequest.CrearPregunta.Where(x => x.PreguntaArchivoId == Guid.Empty).ToList();
                            if (questionsToCreate.Any())
                            {
                                await _createPreguntaCommandHandler.Execute(questionsToCreate, item.IdItem, rfx.IdRfx, null);
                            }

                        }
                    }

                }
                //Elimina los items

                //Crear Items Nuevos
                var newItems = updateRfxRequest.UpdateItemRequest.Where(x => x.IdItem == null).ToList();
                if (newItems.Any())
                {
                    var items = _mapper.Map<List<Domain.Models.Item.CreateItemRequest>>(newItems);
                    await _createItemCommandHandler.Execute(items, rfx.IdRfx, updateRfxRequest.CrearPregunta);
                }
                //Archivos sobre 

                //Elimar los sobores quitados
                if (updateRfxRequest.ArchivoSobre != null)
                {
                    var archiveIdsToUpdate = updateRfxRequest.ArchivoSobre
                        .Where(x => x.IdArchivoSobre != Guid.Empty).Select(x => x.IdArchivoSobre)
                        .ToList() ?? new List<Guid?>();

                    if (archiveIdsToUpdate.Any())
                    {

                        List<Domain.Entities.Archivos.ArchivoSobre> ArchivoSobreupd = _dataBaseService.PreguntaSobreRfx
                          .Include(x => x.PreguntaArchivo)
                          .Include(x => x.Rfx)
                          .Include(x => x.PreguntaArchivo.ArchivoSobre)
                          .Where(x => !archiveIdsToUpdate.Contains(x.PreguntaArchivo.ArchivoSobreId) && x.RfxId == rfx.IdRfx)
                          .Select(x => x.PreguntaArchivo.ArchivoSobre)
                          .ToList();

                        await _deleteSobreCommandHandler.Execute(ArchivoSobreupd);

                        List<Domain.Entities.Archivos.ArchivoSobre> ArchivoSobreupdate = _dataBaseService.PreguntaSobreRfx
                             .Include(x => x.PreguntaArchivo)
                             .Include(x => x.Rfx)
                             .Include(x => x.PreguntaArchivo.ArchivoSobre)
                             .Where(x => archiveIdsToUpdate.Contains(x.PreguntaArchivo.ArchivoSobreId) && x.RfxId == rfx.IdRfx)
                             .Select(x => x.PreguntaArchivo.ArchivoSobre)
                             .ToList();

                        if (ArchivoSobreupdate != null && ArchivoSobreupdate.Count > 0)
                        {
                            foreach (var sobreExistente in ArchivoSobreupdate)
                            {
                                var sobreRequest = updateRfxRequest.ArchivoSobre
                                    .FirstOrDefault(s => s.IdArchivoSobre == sobreExistente.IdArchivo);

                                if (sobreRequest == null)
                                    continue;

                                var dto = new ArchivoSobrePreguntas
                                {
                                    ArchivoSobre = new ArchivoSobre
                                    {
                                        IdArchivo = sobreExistente.IdArchivo,
                                        NombreArchivo = sobreRequest.NombreSobre,
                                        TipoArchivoId = sobreExistente.TipoArchivoId,
                                        FechaCreacion = sobreExistente.FechaCreacion,
                                        FechaActualizacion = DateTime.Now
                                    },
                                    CrearPregunta = new List<PreguntaDto>()
                                };

                                var preguntasExistentes = _dataBaseService.PreguntaArchivo
                                    .Where(p => p.ArchivoSobreId == sobreExistente.IdArchivo)
                                    .ToList();

                                // Validar preguntas eliminadas
                                var idsEnRequest = sobreRequest.CrearPregunta
                                    .Where(p => p.PreguntaArchivoId != null)
                                    .Select(p => p.PreguntaArchivoId!.Value)
                                    .ToHashSet();

                                var preguntasAEliminar = preguntasExistentes
                                    .Where(p => !idsEnRequest.Contains(p.IdPreguntaArchivo))
                                    .ToList();

                                if (preguntasAEliminar.Any())
                                {
                                    await _deletePreguntaCommandHandler.Execute(preguntasAEliminar);
                                }

                                // Validar preguntas nuevas o modificadas
                                foreach (var preguntaRequest in sobreRequest.CrearPregunta)
                                {
                                    var preguntaExistente = preguntasExistentes
                                        .FirstOrDefault(p => p.ValoresArchivoId == preguntaRequest.ValoresArchivoId);

                                    if (preguntaExistente == null)
                                    {
                                        dto.CrearPregunta.Add(new PreguntaDto
                                        {
                                            IdPreguntaArchivo = null,
                                            Pregunta = preguntaRequest.Pregunta,
                                            Detalle = preguntaRequest.Detalle,
                                            TipoRespuesta = (Guid)preguntaRequest.ValoresArchivoId,
                                            Requerido = (bool)preguntaRequest.Requerido,
                                            Opciones = preguntaRequest.ValoresArchivoJson ?? new List<string>()
                                        });
                                    }
                                    else
                                    {
                                        var valoresArchivoJson = preguntaExistente.ValoresArchivoJson != null
                                            ? JsonConvert.DeserializeObject<List<string>>(preguntaExistente.ValoresArchivoJson)
                                            : new List<string>();

                                        bool haCambiado =
                                            !string.Equals(preguntaExistente.Pregunta?.Trim(), preguntaRequest.Pregunta?.Trim(), StringComparison.Ordinal) ||
                                            !string.Equals(preguntaExistente.Detalle?.Trim(), preguntaRequest.Detalle?.Trim(), StringComparison.Ordinal) ||
                                            preguntaExistente.Requerido != (preguntaRequest.Requerido ?? false) ||
                                            !valoresArchivoJson.SequenceEqual(preguntaRequest.ValoresArchivoJson ?? new List<string>());

                                        if (haCambiado)
                                        {
                                            dto.CrearPregunta.Add(new PreguntaDto
                                            {
                                                IdPreguntaArchivo = preguntaExistente.IdPreguntaArchivo,
                                                Pregunta = preguntaRequest.Pregunta,
                                                Detalle = preguntaRequest.Detalle,
                                                TipoRespuesta = (Guid)preguntaRequest.ValoresArchivoId,
                                                Requerido = (bool)preguntaRequest.Requerido,
                                                Opciones = preguntaRequest.ValoresArchivoJson ?? new List<string>()
                                            });
                                        }
                                    }
                                }

                                await _updateSobreCommandHandler.Execute(dto);
                            }
                        }


                    }
                }

                var newArchives = updateRfxRequest.ArchivoSobre.Where(x => x.IdArchivoSobre == Guid.Empty).ToList();

                if (newArchives.Any())
                {
                    var sobrentity = _mapper.Map<List<Domain.Models.Pregunta.ArchivoSobre>>(newArchives);
                    await _createSobreCommandHandler.Execute(sobrentity, rfx.IdRfx);

                }

                await _dataBaseService.SaveAsync();
                return ResponseApiService.Response(StatusCodes.Status201Created, null);
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Rfx No Existe");

            }

        }

    }
}
