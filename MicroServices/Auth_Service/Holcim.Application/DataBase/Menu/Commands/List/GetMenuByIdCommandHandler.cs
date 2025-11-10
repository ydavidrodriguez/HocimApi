using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Menu.Commands.List
{
    public class GetMenuByIdCommandHandler : IGetMenuByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetMenuByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid IdUsuario)
        {

            List<Guid> rolUsuario = _dataBaseService.RolUsuario
                .Where(x => x.UsuarioId == IdUsuario).Select(x => x.RolId).ToList();

            List<Domain.Entities.RolMenu.RolMenu> rolMenu =
             _dataBaseService.RolMenu
                     .Include(x => x.Rol)
                     .Include(x => x.Menu)
                     .Where(x => rolUsuario.Contains(x.RolId)).ToList();


            return ResponseApiService.Response(StatusCodes.Status201Created, rolMenu);
        }


    }
}
