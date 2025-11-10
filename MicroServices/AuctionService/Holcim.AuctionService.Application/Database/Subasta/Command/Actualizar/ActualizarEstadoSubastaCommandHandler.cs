using Holcim.AuctionService.Application.Enum;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Domain.Models.Correo;
using Holcim.AuctionService.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public class ActualizarEstadoSubastaCommandHandler : IActualizarEstadoSubastaCommandHandler
    {
        private readonly IDapperProcedure _dapperProcedure;
        private readonly IDataBaseService _dataBaseService;
        private readonly IEstadoService _estadoService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ActualizarEstadoSubastaCommandHandler(
            IEstadoService estadoService,
            IDapperProcedure dapperProcedure,
            IDataBaseService dataBaseService,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor

         )
        {
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
            _estadoService = estadoService;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<object> Execute(ActualizarEstadoBaseRequest request)
        {

            var EntitieSubasta = _dataBaseService.Subasta.Where(x => x.IdSubasta == request.SubastaId).FirstOrDefault();
            TrazabilidadSubasta trazabilidadSubasta = new TrazabilidadSubasta();

            if (EntitieSubasta != null)
            {
                EntitieSubasta.EstadoId = request.EstadoId;

                var lang = _httpContextAccessor.HttpContext?.Items["lang"] as string ?? "es";
                var client = _httpClientFactory.CreateClient("ApiGatewayService");
                var url = $"/auth/api/Estado/GetListEstadoAll?EstadoId={request.EstadoId}&lang={lang}";
                var estado = await client.GetAsync(url);
                if (estado.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return ResponseApiService.Response(StatusCodes.Status304NotModified, estado.RequestMessage);
                }
                var dataEstado = await estado.Content.ReadAsStringAsync();
                BaseResponseModel Estado = JsonConvert.DeserializeObject<BaseResponseModel>(dataEstado);
                List<EstadoRequest> estadorequest = Estado.Data.ToObject<List<EstadoRequest>>();

                if (estadorequest.First().Nombre == EnumsProcedure.Suspendido.GetEnumMemberValue())
                {
                    EntitieSubasta.FechaInicio = request.FechaInicioSuspension;
                    EntitieSubasta.FechaFin = request.FechaSuspension;
                    trazabilidadSubasta.MotivoEstado = request.Motivo;
                }
                trazabilidadSubasta.SubastaId = request.SubastaId;
                trazabilidadSubasta.IdTrazabilidadSubasta = Guid.NewGuid();
                trazabilidadSubasta.EstadoId = request.EstadoId;
                trazabilidadSubasta.UsuarioId = request.UsuarioId;
                trazabilidadSubasta.FechaCambio = DateTime.Now;



                _dataBaseService.Subasta.Update(EntitieSubasta);

            }

            //if (request != null)
            //{
            //    switch (request)
            //    {
            //        case ActualizarEstadoRequest suspenderRequest:
            //            if (suspenderRequest.FechaInicio.HasValue)
            //            {
            //                subasta.FechaInicio = suspenderRequest.FechaInicio.Value;
            //            }

            //            if (suspenderRequest.FechaFin.HasValue)
            //            {
            //                subasta.FechaFin = suspenderRequest.FechaFin.Value;
            //            }
            //            if (suspenderRequest.Motivo != null && suspenderRequest.Motivo != "")
            //            {
            //                trazabilidadSubasta.MotivoEstado = suspenderRequest.Motivo;
            //            }
            //            await _subastaSchedulerService.ActualizarSubastaAsync(
            //                idSubasta,
            //                subasta.FechaInicio ?? DateTime.Now,
            //                subasta.FechaFin ?? DateTime.Now);
            //            break;
            //        case ActualizarEstadoFinalizadaRequest finalizarRequest:
            //            if (finalizarRequest.Ganadores != null)
            //            {
            //                foreach (var otorgar in finalizarRequest.Ganadores)
            //                {
            //                    var ganadorSubasta = new GanadorSubasta
            //                    {
            //                        IdGanadorSubasta = Guid.NewGuid(),
            //                        ItemId = otorgar.ItemId,
            //                        SubastaId = idSubasta,
            //                        ProveedorId = otorgar.GanadorId,
            //                        Cantidad = otorgar.Cantidad,
            //                        ValorOferta = otorgar.ValorOferta
            //                    };

            //                    _dataBaseService.GanadorSubasta.Add(ganadorSubasta);
            //                }
            //            }
            //            //await _subastaSchedulerService.CancelarSubastaAsync(
            //            //    idSubasta);
            //            //break;
            //    }
            //    trazabilidadSubasta.UsuarioId = request.UsuarioId;
            //}


            _dataBaseService.TrazabilidadSubasta.Add(trazabilidadSubasta);
            await _dataBaseService.SaveAsync();
            return ResponseApiService.Response(StatusCodes.Status200OK, null, "Estado de subasta actualizado correctamente.");

        }

    }


}
