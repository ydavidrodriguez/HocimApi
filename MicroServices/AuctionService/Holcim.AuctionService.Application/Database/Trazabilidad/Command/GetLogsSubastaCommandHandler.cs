using AutoMapper;
using Holcim.AuctionService.Application.External;
using Holcim.AuctionService.Application.Feature;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.AuctionService.Application.Database.Trazabilidad.Commands
{
    public class GetLogsSubastaCommandHandler : IGetLogsSubastaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public GetLogsSubastaCommandHandler(IDataBaseService dataBaseService, IMapper mapper, IDapperProcedure dapperProcedure)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
        }

        public async Task<object> Execute(Guid auctionId)
        {
            var trazabilidad = _dataBaseService.TrazabilidadSubasta
            .Where(t => t.SubastaId == auctionId)
            .Select(t => new TrazabilidadDto
            {
                IdTrazabilidadSubasta = t.IdTrazabilidadSubasta,
                UsuarioId = t.UsuarioId,
                EstadoNombre = t.Estado != null ? t.Estado.Nombre : null,
                EstadoId = t.EstadoId,
                FechaCambio = t.FechaCambio,
                SubastaId = t.SubastaId,
                MotivoEstado = t.MotivoEstado,
                UsuarioNombre = null,
                Email = null
            })
            .ToList();
            if (!trazabilidad.Any())
            {
                return ResponseApiService.Response(StatusCodes.Status404NotFound, null, "No se encontraron registros para la subasta especificada.");
            }
            foreach (var item in trazabilidad)
            {
                if (item.UsuarioId != Guid.Empty)
                {
                    var parameters = new { IdUsuario = item.UsuarioId };
                    var userString = _dapperProcedure.GetQuery(parameters, "GETUSERBYID");
                    if (!string.IsNullOrEmpty(userString))
                    {
                    var user = JsonConvert.DeserializeObject<List<dynamic>>(userString)?.FirstOrDefault();
                    if (user != null && user.Nombre != null)
                    {
                        item.UsuarioNombre = $"{user.Nombre} {user.Apellido}";
                        item.Email = $"{user.Correo}";
                    }
                    else{

                        item.UsuarioNombre = "System";
                    }
                    }
                }
                else{
                    item.UsuarioNombre = "System";
                }
            }
            return ResponseApiService.Response(StatusCodes.Status200OK, trazabilidad);
        }
    }
}
