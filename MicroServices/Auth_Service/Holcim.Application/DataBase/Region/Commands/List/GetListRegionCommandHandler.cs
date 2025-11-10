using AutoMapper;

namespace Holcim.Application.DataBase.Region.Commands.List
{
    public class GetListRegionCommandHandler : IGetListRegionCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetListRegionCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Region.Region>> Execute(string? Nombre)
        {
            if (string.IsNullOrWhiteSpace(Nombre)) 
            {
                return _dataBaseService.Region.ToList();

            }
            else 
            { 
                return _dataBaseService.Region.Where(x=> x.Nombre.Contains(Nombre)).ToList();
            }

            
        }


    }
}
