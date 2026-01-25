using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Psc;
using Microsoft.AspNetCore.Http;


namespace Holcim.Application.DataBase.Psc.Commands.Create
{
    public class CreatePscCommandHandler : ICreatePscCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreatePscCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(List<CreatePscRequest> CreatePscRequests)
        {
            var duplicates = new List<CreatePscRequest>();
            var created = new List<CreatePscRequest>();

            if (CreatePscRequests == null || !CreatePscRequests.Any())
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, "No hay datos para procesar");

            foreach (var req in CreatePscRequests)
            {
                if (_dataBaseService.Pscs.Any(p => p.PscsId == req.PscsId))
                {
                    duplicates.Add(req);
                    continue;
                }

                var entity = _mapper.Map<Domain.Entities.Pscs.Pscs>(req);
                entity.IdPscs = Guid.NewGuid();
                entity.ColumnasExtras = req.ColumnasExtras;
                entity.Estado = true;
                entity.FechaCreacion = DateTime.Now;
                entity.FechaActulizacion = DateTime.Now;
                _dataBaseService.Pscs.Add(entity);
                created.Add(req);
            }

            if (created.Any())
                await _dataBaseService.SaveAsync();

            var result = new {
                Created = created,
                Duplicates = duplicates
            };

            var message = duplicates.Any() ? "Algunos PSCs ya existían" : "Pscs creados correctamente";
            var status = created.Any() ? StatusCodes.Status201Created : StatusCodes.Status202Accepted;

            return ResponseApiService.Response(status, result, message);
        }
    }
}
