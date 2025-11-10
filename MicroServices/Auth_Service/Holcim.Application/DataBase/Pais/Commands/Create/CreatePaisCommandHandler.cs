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

        public async Task<object> Execute(CreatePaisRequest createPaisRequest)
        {
            if (_dataBaseService.Pais.Where(x => x.Nombre.Trim() == createPaisRequest.Nombre.Trim()).FirstOrDefault() == null)
            {
                string nombretraduccion = await _GetTraduccionService.Execute(createPaisRequest.Nombre);

                var Entitymapper = _mapper.Map<Domain.Entities.Pais.Pais>(createPaisRequest);
                Entitymapper.IdPais = Guid.NewGuid();
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                Entitymapper.Nombre = nombretraduccion;
                Entitymapper.TipoPaisId = _dataBaseService.TipoPais.Where(x => x.Descripcion == EnumDomain.PaisGrud.GetEnumMemberValue().ToString()).First().IdTipoPais;
                _dataBaseService.Pais.Add(Entitymapper);

                ZonaHorariaPais zonaHorariaPais = new ZonaHorariaPais();

                zonaHorariaPais.IdZonaHorariaPais = Guid.NewGuid();
                zonaHorariaPais.PaisId = Entitymapper.IdPais;
                zonaHorariaPais.ZonaHorariaId = createPaisRequest.ZonaHoraria;
                zonaHorariaPais.Estado = true;

                _dataBaseService.ZonaHorariaPais.Add(zonaHorariaPais);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, createPaisRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Pais Ya Registrado");
            }
        }

    }
}
