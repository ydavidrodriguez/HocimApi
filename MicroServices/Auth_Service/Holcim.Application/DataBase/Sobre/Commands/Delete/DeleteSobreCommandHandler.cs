using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Archivos;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Sobre.Commands.Delete
{
    public class DeleteSobreCommandHandler : IDeleteSobreCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public DeleteSobreCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute(List<ArchivoSobre> ArchivoSobre)
        {

            if (ArchivoSobre != null)
            {
                if (ArchivoSobre.Count > 0)
                {
                    foreach (var archivosobreitem in ArchivoSobre)
                    {
                        // Eliminar registros relacionados en PreguntaSobreRfx
                        var preguntasSobreRfx = _dataBaseService.PreguntaSobreRfx
                            .Where(x => x.PreguntaArchivo.ArchivoSobreId == archivosobreitem.IdArchivo)
                            .ToList();
                        _dataBaseService.PreguntaSobreRfx.RemoveRange(preguntasSobreRfx);

                        // Eliminar registros relacionados en PreguntaArchivo
                        var preguntasArchivo = _dataBaseService.PreguntaArchivo
                            .Where(x => x.ArchivoSobreId == archivosobreitem.IdArchivo)
                            .ToList();

                        _dataBaseService.PreguntaArchivo.RemoveRange(preguntasArchivo);

                        _dataBaseService.ArchivoSobre.Remove(archivosobreitem);

                        await _dataBaseService.SaveAsync();
                    }
                }

            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Archivos sobre Eliminados Correctamente");

        }

    }
}
