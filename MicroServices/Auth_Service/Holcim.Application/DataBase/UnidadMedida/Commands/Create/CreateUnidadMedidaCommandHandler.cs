using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.UnidadMedida;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.UnidadMedida.Commands.Create
{
    public class CreateUnidadMedidaCommandHandler : ICreateUnidadMedidaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateUnidadMedidaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(CreateUnidadMedidaRequest createUnidadMedidaRequest)
        {

            if (_dataBaseService.UnidadMedida.Where(x => x.UdmCode == createUnidadMedidaRequest.UdmCode).FirstOrDefault() == null)
            {
                var Entitymapper = _mapper.Map<Domain.Entities.UnidadMedida.UnidadMedida>(createUnidadMedidaRequest);
                Entitymapper.IdUnidadMedida = Guid.NewGuid();
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                _dataBaseService.UnidadMedida.Add(Entitymapper);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, createUnidadMedidaRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Unidad Medida Ya Registrada");
            }

        }

    }
}
