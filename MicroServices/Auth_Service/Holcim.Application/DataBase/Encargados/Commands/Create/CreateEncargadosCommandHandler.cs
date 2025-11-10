using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Rfx;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Encargados.Commands.Create
{
    public class CreateEncargadosCommandHandler : ICreateEncargadosCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateEncargadosCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(List<Guid> encargados, Guid rfxId)
        {
            if (encargados != null)
            {
                foreach (var encargado in encargados)
                {
                    _dataBaseService.UsuarioEncargadoRfx.Add(new UsuarioEncargadoRfx
                    {
                        IdUsuarioEncargadoRfx = Guid.NewGuid(),
                        UsuarioId = encargado,
                        RfxId = rfxId,
                        Estado = true
                    });
                }

                return ResponseApiService.Response(StatusCodes.Status201Created, "Usuario Encargado creado Correctamente");
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, "No tiene Usuario Encargado");
            }
        }
    }
}
