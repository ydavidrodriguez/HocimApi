using AutoMapper;
using Holcim.Domain.Models.Region;

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
            _mapper = mapper;
            _mapper = mapper;
        }

        public async Task<CreateRegionRequest> Execute(CreateRegionRequest CreateRegionRequest)
        {
            var Entitymapper = _mapper.Map<Domain.Entities.Region.Region>(CreateRegionRequest);
            Entitymapper.IdRegion = Guid.NewGuid();
            Entitymapper.Estado = true;
            Entitymapper.FechaCreacion = DateTime.Now;
            Entitymapper.FechaActulizacion = DateTime.Now;
            _dataBaseService.Region.Add(Entitymapper);
            await _dataBaseService.SaveAsync();

            return CreateRegionRequest;

        }

    }
}
