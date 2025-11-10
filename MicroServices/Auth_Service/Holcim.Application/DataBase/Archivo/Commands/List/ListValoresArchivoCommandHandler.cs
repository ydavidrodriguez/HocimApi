using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Archivo.Commands.List
{
    public class ListValoresArchivoCommandHandler : IListValoresArchivoCommand
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListValoresArchivoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute()
        {
            List<Domain.Entities.Archivos.ValoresArchivo> valoresArchivo = _dataBaseService.ValoresArchivo.ToList();
            return ResponseApiService.Response(StatusCodes.Status201Created, valoresArchivo);
        }


    }
}
