using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Informe.Commands.List
{
    public class ListInformesCommandHandler : IListInformesCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListInformesCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(string? Nombre)
        {

            if (!string.IsNullOrEmpty(Nombre))
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Informes.Where(x => x.Nombre.Contains(Nombre)).ToList());
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Informes.ToList());
            }
        }

    }
}
