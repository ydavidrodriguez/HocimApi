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

        public async Task<object> Execute(CreateMonedaRequest createMonedaRequest)
        {
            if (_dataBaseService.Moneda.Where(x => x.Nombre.Trim() == createMonedaRequest.Nombre.Trim()).FirstOrDefault() == null)
            {
                var Entitymapper = _mapper.Map<Domain.Entities.Moneda.Moneda>(createMonedaRequest);
                Entitymapper.IdMoneda = Guid.NewGuid();
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                _dataBaseService.Moneda.Add(Entitymapper);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, createMonedaRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Moneda Ya Registrada");
            }
        }

    }
}
