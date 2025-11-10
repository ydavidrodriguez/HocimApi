using AutoMapper;
using Holcim.Domain.Models.Rol;
using Holcim.Domain.Models.Usuario;

namespace Holcim.Application.DataBase.Rol.Commands.Create
{
    public class CreateRolCommandHandler : ICreateRolCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateRolCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _mapper = mapper;
        }

        public async Task<CreateRolRequest> Execute(CreateRolRequest createRolRequest)
        {
            var Entitymapper = _mapper.Map<Domain.Entities.Rol.Rol>(createRolRequest);
            Entitymapper.IdRol = Guid.NewGuid();
            _dataBaseService.Rol.Add(Entitymapper);
            await _dataBaseService.SaveAsync();

            return createRolRequest;
        }

    }
}
