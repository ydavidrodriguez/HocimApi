using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Moneda.Commands.List
{
    public class ListMonedaCommandHandler : IListMonedaCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListMonedaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(string? nombre, string codigo)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Moneda.Where(x => x.Nombre.Contains(nombre)).ToList());
            }
            else if (!string.IsNullOrEmpty(codigo))
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Moneda.Where(x => x.Nombre.Contains(codigo)).ToList());
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Moneda.ToList());
            }
        }

    }
}
