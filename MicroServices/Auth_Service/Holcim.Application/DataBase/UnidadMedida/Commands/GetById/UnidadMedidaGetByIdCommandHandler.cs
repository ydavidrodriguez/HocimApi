using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.UnidadMedida.Commands.GetById
{
    public class UnidadMedidaGetByIdCommandHandler : IUnidadMedidaGetByIdCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UnidadMedidaGetByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid IdUnidadMedida)
        {
            var dataservice = _dataBaseService.UnidadMedida.Where(x=> x.IdUnidadMedida == IdUnidadMedida);
            return ResponseApiService.Response(StatusCodes.Status201Created, dataservice);

        }

    }
}
