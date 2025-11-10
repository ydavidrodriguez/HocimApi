using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Moneda.Commands.List
{
    public class ListMonedaByIdCommandHandler : IListMonedaByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListMonedaByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid MonedaId)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Moneda
                .Where(x => x.IdMoneda == MonedaId).ToList());
        }
    }
}
