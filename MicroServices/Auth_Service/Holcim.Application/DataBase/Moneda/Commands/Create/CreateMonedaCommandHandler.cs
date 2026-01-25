using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Moneda;
using Microsoft.AspNetCore.Http;


namespace Holcim.Application.DataBase.Moneda.Commands.Create
{
    public class CreateMonedaCommandHandler : ICreateMonedaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateMonedaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute(List<CreateMonedaRequest> createMonedaRequests)
        {
            var duplicates = new List<CreateMonedaRequest>();
            var created = new List<CreateMonedaRequest>();

            if (createMonedaRequests == null || !createMonedaRequests.Any())
                return ResponseApiService.Response(StatusCodes.Status400BadRequest,string.Empty, "No hay datos para procesar");

            foreach (var req in createMonedaRequests)
            {
                if (_dataBaseService.Moneda.Any(m => m.Codigo == req.Codigo))
                {
                    duplicates.Add(req);
                    continue;
                }

                var entity = _mapper.Map<Domain.Entities.Moneda.Moneda>(req);
                entity.IdMoneda = Guid.NewGuid();
                entity.ColumnasExtras = req.ColumnasExtras;
                entity.Estado = true;
                entity.FechaCreacion = DateTime.Now;
                entity.FechaActulizacion = DateTime.Now;
                _dataBaseService.Moneda.Add(entity);
                created.Add(req);
            }

            if (created.Any())
                await _dataBaseService.SaveAsync();

            var result = new {
                Created = created,
                Duplicates = duplicates
            };

            var message = duplicates.Any() ? "Algunas monedas ya existían" : "Monedas creadas correctamente";
            var status = created.Any() ? StatusCodes.Status201Created : StatusCodes.Status202Accepted;

            return ResponseApiService.Response(status, result, message);
        }

    }
}
