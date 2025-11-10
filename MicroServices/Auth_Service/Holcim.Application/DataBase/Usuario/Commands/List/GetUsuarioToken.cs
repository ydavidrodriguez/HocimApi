using AutoMapper;

namespace Holcim.Application.DataBase.Usuario.Commands.List
{
    public class GetUsuarioToken : IGetUsuarioToken
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUsuarioToken(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Usuario.UsuarioToken> Execute(Guid idusuario)
        {
            return _dataBaseService.UsuarioToken.Where(x=> x.Idusuario == idusuario ).FirstOrDefault();
        }

    }
}
