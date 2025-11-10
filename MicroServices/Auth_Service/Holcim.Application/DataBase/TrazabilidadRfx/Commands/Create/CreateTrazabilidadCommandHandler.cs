using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.TrazabilidadRfx.Commands.Create
{
    public class CreateTrazabilidadCommandHandler : ICreateTrazabilidadCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateTrazabilidadCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(CreateRfxRequest request, Guid rfxId)
        {
            _dataBaseService.TrazabilidadRfx.Add(new Domain.Entities.Rfx.TrazabilidadRfx
            {
                RfxId = rfxId,
                EstadoId = request.EstadoId,
                FechaCambio = DateTime.Now,
                UsuarioId = request.UsuarioCreacion
            });

            return ResponseApiService.Response(StatusCodes.Status201Created, "Trazabilidad Creada");

        }

    }
}
