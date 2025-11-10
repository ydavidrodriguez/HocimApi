using AutoMapper;

namespace Holcim.Application.DataBase.Menu.Commands.List
{
    public class ListMenuCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListMenuCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Menu.Menu>> Execute()
        {
            return _dataBaseService.Menu.ToList();
        }

    }
}
