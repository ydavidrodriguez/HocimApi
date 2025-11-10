using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Estado.TipoEstado.List
{
    public class ListTipoEstadoCommandHandler : IListTipoEstadoCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListTipoEstadoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute()
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.TipoEstado.ToList());
        }

    }
}
