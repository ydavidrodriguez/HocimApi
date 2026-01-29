using AutoMapper;
using Holcim.Application.External.Traduccion;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Entities.ZonaHoraria;
using Holcim.Domain.Models;
using Holcim.Domain.Models.Idioma;
using Holcim.Domain.Models.Pais;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Holcim.Application.DataBase.Pais.Commands.Create
{
    public class CreatePaisCommandHandler : ICreatePaisCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGetTraduccionService _GetTraduccionService;

        public CreatePaisCommandHandler(IDataBaseService dataBaseService, IMapper mapper, IHttpClientFactory httpClientFactory, IGetTraduccionService getTraduccionService)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _GetTraduccionService = getTraduccionService;
        }

        public async Task<object> Execute(List<CreatePaisRequest> createPaisRequest)
        {
            var duplicates = new List<CreatePaisRequest>();
            var created = new List<CreatePaisRequest>();

            if (createPaisRequest == null || !createPaisRequest.Any())
                return ResponseApiService.Response(StatusCodes.Status400BadRequest, string.Empty, "No hay datos para procesar");

            foreach (var req in createPaisRequest)
            {
                if (_dataBaseService.Pais.Any(x => x.Nombre == req.Nombre))
                {
                    duplicates.Add(req);
                    continue;
                }

                var Entitymapper = _mapper.Map<Domain.Entities.Pais.Pais>(req);
                Entitymapper.IdPais = Guid.NewGuid();
                Entitymapper.ColumnasExtras = req.ColumnasExtras;
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                Entitymapper.Nombre = req.Nombre;
                Entitymapper.TipoPaisId = _dataBaseService.TipoPais.Where(x => x.Descripcion == EnumDomain.PaisGrud.GetEnumMemberValue().ToString()).First().IdTipoPais;
                _dataBaseService.Pais.Add(Entitymapper);

                ZonaHorariaPais zonaHorariaPais = new ZonaHorariaPais();

                zonaHorariaPais.IdZonaHorariaPais = Guid.NewGuid();
                zonaHorariaPais.PaisId = Entitymapper.IdPais;
                zonaHorariaPais.ZonaHorariaId = req.ZonaHoraria;
                zonaHorariaPais.Estado = true;


                _dataBaseService.Pais.Add(Entitymapper);
                created.Add(req);
            }

            if (created.Any())
                await _dataBaseService.SaveAsync();

            var result = new
            {
                Created = created,
                Duplicates = duplicates
            };

            var message = duplicates.Any() ? "Algunos paises ya existían" : "Paises creados correctamente";
            var status = created.Any() ? StatusCodes.Status201Created : StatusCodes.Status202Accepted;

            return ResponseApiService.Response(status, result, message);


        }

    }
}
