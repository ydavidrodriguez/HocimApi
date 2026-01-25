using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Rfx;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Pais.Commands.Create
{
    public class CreateRfxPaisCommandHandler : ICreateRfxPaisCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateRfxPaisCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(IEnumerable<Guid>? paises, Guid rfxId)
        {
            if (paises == null || !paises.Any())
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Sin gru para asociar");

            foreach (var pais in paises)
            {
                if (!_dataBaseService.RfxPais.Any(x => x.PaisId == pais && x.RfxId == rfxId))
                {
                    _dataBaseService.RfxPais.Add(new RfxPais
                    {
                        IdRfxPais = Guid.NewGuid(),
                        PaisId = pais,
                        RfxId = rfxId
                    });
                }
            }

            return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Pais Asociado al rfx");
        }


    }
}
