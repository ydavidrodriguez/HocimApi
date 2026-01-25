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

        public async Task<object> Execute(List<CreateUnidadMedidaRequest> createUnidadMedidaRequest)
        {
            var duplicates = new List<CreateUnidadMedidaRequest>();
            var created = new List<CreateUnidadMedidaRequest>();

            if (createUnidadMedidaRequest == null || !createUnidadMedidaRequest.Any())
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, "No hay datos para procesar");

            foreach (var createUnidadMedida in createUnidadMedidaRequest)
            {
                if (_dataBaseService.UnidadMedida.Any(x => x.UdmCode == createUnidadMedida.UdmCode))
                {
                    duplicates.Add(createUnidadMedida);
                    continue;
                }

                var Entitymapper = _mapper.Map<Domain.Entities.UnidadMedida.UnidadMedida>(createUnidadMedida);
                Entitymapper.IdUnidadMedida = Guid.NewGuid();
                Entitymapper.ColumnasExtras = createUnidadMedida.ColumnasExtras;
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                _dataBaseService.UnidadMedida.Add(Entitymapper);
                created.Add(createUnidadMedida);

            }

            if (created.Any())
                await _dataBaseService.SaveAsync();

            var result = new
            {
                Created = created,
                Duplicates = duplicates
            };

            var message = duplicates.Any() ? "Algunas unidades de medida ya existían" : "Unidades de medida creadas correctamente";
            var status = created.Any() ? StatusCodes.Status201Created : StatusCodes.Status202Accepted;

            return ResponseApiService.Response(status, result, message);

        }
    }

}