using AutoMapper;
using Holcim.Domain.Models.Menu;

namespace Holcim.Application.DataBase.Menu.Commands.Create
{
    public class CreateMenuCommandHandler : ICreateMenuCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateMenuRequest> Execute(CreateMenuRequest createMenuRequest)
        {
            var Entitymapper = _mapper.Map<Domain.Entities.Menu.Menu>(createMenuRequest);
            Entitymapper.IdMenu = Guid.NewGuid();
            _dataBaseService.Menu.Add(Entitymapper);
            await _dataBaseService.SaveAsync();

            return createMenuRequest;
        }

    }
}
