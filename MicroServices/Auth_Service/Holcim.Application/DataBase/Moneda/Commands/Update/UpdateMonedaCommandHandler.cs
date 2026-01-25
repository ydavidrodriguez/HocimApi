using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Moneda;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Moneda.Commands.Update
{
    public class UpdateMonedaCommandHandler : IUpdateMonedaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateMonedaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdateMonedaRequest UpdateMonedaRequest)
        {
            var Entity = _dataBaseService.Moneda.Where(x => x.IdMoneda == UpdateMonedaRequest.IdMoneda).FirstOrDefault();
            if (Entity != null)
            {
                var Moneda = _dataBaseService.Moneda.Where(x => x.Codigo == UpdateMonedaRequest.Codigo && x.IdMoneda != UpdateMonedaRequest.IdMoneda).FirstOrDefault();
                if (Moneda == null)
                {
                    Entity.Nombre = UpdateMonedaRequest.Nombre;
                    Entity.Codigo = UpdateMonedaRequest.Codigo;
                    Entity.Nombre = UpdateMonedaRequest.Nombre;
                    Entity.Descripcion = UpdateMonedaRequest.Descripcion;
                    Entity.ColumnasExtras = UpdateMonedaRequest.ColumnasExtras;
                    Entity.Estado = UpdateMonedaRequest.Estado;
                    Entity.FechaActulizacion = DateTime.Now;
                    _dataBaseService.Moneda.Update(Entity);
                    await _dataBaseService.SaveAsync();

                    return ResponseApiService.Response(StatusCodes.Status201Created, UpdateMonedaRequest);

                }
                else
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Moneda Ya Existe");
                }

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Moneda Ya Existe");
            }

        }

    }
}
