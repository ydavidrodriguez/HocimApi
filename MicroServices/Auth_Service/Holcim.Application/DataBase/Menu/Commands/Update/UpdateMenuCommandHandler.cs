using AutoMapper;
using Holcim.Domain.Models.Menu;
using Holcim.Domain.Models.Rol;

namespace Holcim.Application.DataBase.Menu.Commands.Update
{
    public class UpdateMenuCommandHandler : IUpdateMenuCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateMenuCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateMenuRequest> Execute(UpdateMenuRequest updateMenuRequest)
        {
            var Entitymapper = _mapper.Map<Domain.Entities.Menu.Menu>(updateMenuRequest);
            _dataBaseService.Menu.Update(Entitymapper);
            await _dataBaseService.SaveAsync();

            return updateMenuRequest;
        }


    }
}
