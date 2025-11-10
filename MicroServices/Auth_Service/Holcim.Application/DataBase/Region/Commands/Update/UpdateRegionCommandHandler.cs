using AutoMapper;
using Holcim.Domain.Models.Region;

namespace Holcim.Application.DataBase.Region.Commands.Update
{
    public class UpdateRegionCommandHandler : IUpdateRegionCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateRegionCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateRegionRequest> Execute(UpdateRegionRequest updateRegionRequest)
        {
            Domain.Entities.Region.Region Region = _dataBaseService.Region.Where(x => x.IdRegion == updateRegionRequest.IdRegion).FirstOrDefault();
            if (Region != null)
            {
                Region.FechaActulizacion = DateTime.Now;
                Region.Descripcion = updateRegionRequest.Descripcion;
                Region.Estado = updateRegionRequest.Estado;
                Region.Nombre = updateRegionRequest.Nombre;
                _dataBaseService.Region.Update(Region);
                await _dataBaseService.SaveAsync();
            }

            return updateRegionRequest;
        }

    }
}
