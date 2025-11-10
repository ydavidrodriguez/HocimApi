using AutoMapper;

namespace Holcim.Application.DataBase.Region.Commands.ListById
{
    public class GetListRegionByIdCommandHandler : IGetListRegionByIdCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetListRegionByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Region.Region> Execute(Guid IdRegion)
        {
            return _dataBaseService.Region.Where(x=> x.IdRegion == IdRegion).FirstOrDefault();
        }


    }
}
