using AutoMapper;
using Holcim.Application.DataBase.Pregunta.Commands.Create;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Sobre.Commands.Create
{
    public class CreateSobreCommandHandler : ICreateSobreCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        private readonly ICreatePreguntaCommandHandler _createPreguntaCommandHandler;


        public CreateSobreCommandHandler(IDataBaseService dataBaseService, IMapper mapper,
            ICreatePreguntaCommandHandler createPreguntaCommandHandler, ICreatePreguntaCommandHandler createPreguntaCommandHandler1)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _createPreguntaCommandHandler = createPreguntaCommandHandler;
        }

        public async Task<object> Execute(List<Domain.Models.Pregunta.ArchivoSobre> archivoSobre, Guid rfxId)
        {

            foreach (var itemPreguntaSobre in archivoSobre)
            {
                var archivo = new Domain.Entities.Archivos.ArchivoSobre
                {
                    IdArchivo = Guid.NewGuid(),
                    NombreArchivo = itemPreguntaSobre.NombreSobre,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    TipoArchivoId = _dataBaseService.TipoArchivo.First(x => x.Nombre == EnumDomain.SobreEconómico.GetEnumMemberValue()).IdTipoArchivo
                };
                _dataBaseService.ArchivoSobre.Add(archivo);

                await _createPreguntaCommandHandler.Execute(itemPreguntaSobre.CrearPregunta, Guid.Empty, rfxId,archivo.IdArchivo);
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, "Archivo Creado Correctamente" );
        }

    }
}
