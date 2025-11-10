using Dapper;
using Holcim.AuctionService.Application.Feature;
using Holcim.AuctionService.Application.External;
using Microsoft.AspNetCore.Http;
using Holcim.AuctionService.Services;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Holcim.AuctionService.Domain.Models;


namespace Holcim.AuctionService.Application.Database.Subasta.Command.Update
{
    public class PutUpdateColaboratorsCommandHandler : IPutUpdateColaboratorsCommandHandler
    {
        // private readonly IDataBaseService _dataBaseService;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly IDataBaseService _dataBaseService;
        private readonly IEstadoService _estadoService;

        public PutUpdateColaboratorsCommandHandler(IEstadoService estadoService,IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
            _estadoService = estadoService;
        }

        public async Task<object> Execute(PutUpdateColaboratorsRequest request)
        {


            var subasta = _dataBaseService.Subasta.FirstOrDefault(s => s.IdSubasta == request.IdSubasta);
            if (subasta == null)
            {
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No se encontró la subasta especificada.");
            }
            var colaboradoresActuales = _dataBaseService.UsuarioColaboradorSubasta
                .Where(ucs => ucs.SubastaId == request.IdSubasta)
                .ToList();

            foreach (var colaborador in colaboradoresActuales)
            {
                _dataBaseService.UsuarioColaboradorSubasta.Remove(colaborador);
            }

            foreach (var usuarioId in request.UsuarioId)
            {
                var nuevoColaborador = new UsuarioColaboradorSubasta
                {
                    IdUsuarioColaboradorSubasta = Guid.NewGuid(), // Generar un nuevo ID único
                    SubastaId = request.IdSubasta,
                    UsuarioId = usuarioId,
                    Estado = true // Puedes ajustar este valor según tus necesidades
                };

                _dataBaseService.UsuarioColaboradorSubasta.Add(nuevoColaborador);
            }

            await _dataBaseService.SaveAsync();

            return ResponseApiService.Response(StatusCodes.Status200OK, null, "Subasta actualizada correctamente.");

        }

    }
}
