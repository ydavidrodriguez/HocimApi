using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Estado.Commads.List
{
    public class ListEstadoByTypeCommandHandler : IListEstadoByTypeCommandHandler
    {


        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListEstadoByTypeCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid TipoEstado)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Estado.Where(x => x.TipoEstadoId == TipoEstado).ToList());
        }


    }
}
