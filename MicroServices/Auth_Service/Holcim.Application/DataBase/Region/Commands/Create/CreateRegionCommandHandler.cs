using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Region;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Holcim.Application.DataBase.Region.Commands.Create
{
    public class CreateRegionCommandHandler : ICreateRegionCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateRegionCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(List<CreateRegionRequest> CreateRegionRequests)
        {
            var duplicates = new List<CreateRegionRequest>();
            var created = new List<CreateRegionRequest>();

            if (CreateRegionRequests == null || !CreateRegionRequests.Any())
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, null, "No hay datos para procesar");

            foreach (var req in CreateRegionRequests)
            {
                if (_dataBaseService.Region.Any(r => r.Nombre == req.Nombre))
                {
                    duplicates.Add(req);
                    continue;
                }

                var entity = _mapper.Map<Domain.Entities.Region.Region>(req);
                entity.IdRegion = Guid.NewGuid();
                entity.Estado = true;
                entity.FechaCreacion = DateTime.Now;
                entity.FechaActulizacion = DateTime.Now;
                _dataBaseService.Region.Add(entity);
                created.Add(req);
            }

            if (created.Any())
                await _dataBaseService.SaveAsync();

            var result = new {
                Created = created,
                Duplicates = duplicates
            };

            var message = duplicates.Any() ? "Algunas regiones ya existían" : "Regiones creadas correctamente";
            var status = created.Any() ? StatusCodes.Status201Created : StatusCodes.Status202Accepted;

            return ResponseApiService.Response(status, result, message);
        }

    }
}
