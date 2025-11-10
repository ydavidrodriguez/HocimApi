using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Archivo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Archivo.Commands.List
{
    public class ListArchivosByTypeArchivoCommandHandler : IListArchivosByTypeArchivoCommand
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListArchivosByTypeArchivoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid TipoRfx)
        {
            List<GetArchivosByTypeResponse> ListgetArchivosByTypeResponses = new List<GetArchivosByTypeResponse>();


            var tipoarchivo = _dataBaseService.TipoArchivoRfx
                .Include(x => x.TipoArchivo)
                .Where(x => x.TipoRfxId == TipoRfx).ToList();

            foreach (var item in tipoarchivo)
            {
                GetArchivosByTypeResponse getArchivosByTypeResponse = new GetArchivosByTypeResponse();

                getArchivosByTypeResponse.TipoArchivo = item.TipoArchivo;
                getArchivosByTypeResponse.Archivos = _dataBaseService.ArchivoSobre.Where(x => x.TipoArchivoId == item.TipoArchivoId).ToList();
                ListgetArchivosByTypeResponses.Add(getArchivosByTypeResponse);

            }

            return ResponseApiService.Response(StatusCodes.Status201Created, ListgetArchivosByTypeResponses);

        }


    }
}
