using AutoMapper;

namespace Holcim.Application.DataBase.Departamento
{
    public class ListDepartamentoCommandHandler : IListDepartamentoCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListDepartamentoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Dependencia.Departamento>> Execute()
        {
            return _dataBaseService.Dependencia.ToList();
        }


    }
}
