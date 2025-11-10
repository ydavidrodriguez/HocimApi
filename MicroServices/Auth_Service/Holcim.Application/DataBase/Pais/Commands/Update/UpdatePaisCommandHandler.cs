using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Pais;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Pais.Commands.Update
{
    public class UpdatePaisCommandHandler : IUpdatePaisCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdatePaisCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdatePaisRequest updatePaisRequest)
        {
            var Entity = _dataBaseService.Pais.Where(x => x.IdPais == updatePaisRequest.IdPais).FirstOrDefault();
            if (Entity != null)
            {
                var Pais = _dataBaseService.Pais.Where(x => x.Nombre == updatePaisRequest.Nombre && x.IdPais != updatePaisRequest.IdPais).FirstOrDefault();
                if (Pais == null)
                {
                    Entity.Nombre = updatePaisRequest.Nombre;
                    Entity.Indicativo = updatePaisRequest.Indicativo;
                    Entity.Estado = updatePaisRequest.Estado;
                    Entity.RegionId = updatePaisRequest.RegionId;
                    Entity.FechaActulizacion = DateTime.Now;
                    _dataBaseService.Pais.Update(Entity);
                    await _dataBaseService.SaveAsync();

                    return ResponseApiService.Response(StatusCodes.Status201Created, updatePaisRequest);

                }
                else
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Pais Ya Existe");
                }

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Pais Ya Existe");
            }

        }


    }
}
