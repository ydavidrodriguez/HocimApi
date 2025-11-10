using AutoMapper;
using Holcim.Domain.Models.Rol;
using Holcim.Domain.Models.Usuario;

namespace Holcim.Application.DataBase.Rol.Commands.Update
{
    public class UpdateRolCommandHandler : IUpdateRolCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateRolCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateRolRequest> Execute(UpdateRolRequest UpdateRolRequest)
        {
            var Entitymapper = _mapper.Map<Domain.Entities.Rol.Rol>(UpdateRolRequest);
            _dataBaseService.Rol.Update(Entitymapper);
            await _dataBaseService.SaveAsync();

            return UpdateRolRequest;
        }


    }
}
