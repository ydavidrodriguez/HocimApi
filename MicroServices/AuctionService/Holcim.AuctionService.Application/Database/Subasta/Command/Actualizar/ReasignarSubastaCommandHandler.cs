using Holcim.AuctionService.Application.Feature;
using Microsoft.AspNetCore.Http;
using Holcim.AuctionService.Domain.Models;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Newtonsoft.Json;


namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public class ReasignarSubastaCommandHandler : IReasignarSubastaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;

        public ReasignarSubastaCommandHandler(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<object> Execute(PutReasignarSubastaRequest request)
        {

            try
            {
                var subasta = _dataBaseService.Subasta.FirstOrDefault(s => s.IdSubasta == request.IdSubasta);
                if (subasta == null)
                {
                    return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No se encontró la subasta especificada.");
                }

                UsuarioReasignacionSubasta usuarioReasignacion = new UsuarioReasignacionSubasta();

                usuarioReasignacion.SubastaId = subasta.IdSubasta;
                usuarioReasignacion.UsuarioOld = subasta.UsuarioCreacionId;
                usuarioReasignacion.Estado = true;
                usuarioReasignacion.IdUsuarioReasignacionSubasta = Guid.NewGuid();
                usuarioReasignacion.FechaFinal = request.FechaFinal;
                usuarioReasignacion.MotivoId = request.Motivo;
                usuarioReasignacion.FechaInicio = request.FechaInicio;
                usuarioReasignacion.Usuarios = JsonConvert.SerializeObject(request.UsuarioId);

                _dataBaseService.UsuarioReasignacionSubasta.Add(usuarioReasignacion);

                foreach (var usuarioencargado in request.UsuarioId)
                {
                    UsuarioEncargadoSubasta usuarioEncargadoSubasta = new UsuarioEncargadoSubasta();

                    usuarioEncargadoSubasta.IdUsuarioEncargadoSubasta = Guid.NewGuid();
                    usuarioEncargadoSubasta.UsuarioId = usuarioencargado;
                    usuarioEncargadoSubasta.SubastaId = request.IdSubasta;
                    usuarioEncargadoSubasta.Estado = true;

                    _dataBaseService.UsuarioEncargadoSubasta.Add(usuarioEncargadoSubasta);
                }

                await _dataBaseService.SaveAsync();
                return ResponseApiService.Response(StatusCodes.Status200OK, null, "Subasta reasignada correctamente.");

            }
            catch (System.Exception ex)
            {
                return ResponseApiService.Response(StatusCodes.Status500InternalServerError, null, $"Error: {ex.Message}");
            }
        }

    }
}
