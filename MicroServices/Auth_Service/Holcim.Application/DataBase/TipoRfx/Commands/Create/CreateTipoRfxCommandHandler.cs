using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Rfx;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.TipoRfx.Commands.Create
{
    public class CreateTipoRfxCommandHandler : ICreateTipoRfxCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateTipoRfxCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute(CreateTipoRfxRequest CreateTipoRfxRequest)
        {
            if (_dataBaseService.TipoRfx.Where(x => x.Nombre.Trim() == CreateTipoRfxRequest.Nombre.Trim()).FirstOrDefault() == null)
            {
                var Entitymapper = _mapper.Map<Domain.Entities.TipoRfx.TipoRfx>(CreateTipoRfxRequest);
                Entitymapper.IdTipoRfx = Guid.NewGuid();
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                _dataBaseService.TipoRfx.Add(Entitymapper);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, CreateTipoRfxRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Tipo Rfx Ya Registrado");
            }
        }

    }
}
