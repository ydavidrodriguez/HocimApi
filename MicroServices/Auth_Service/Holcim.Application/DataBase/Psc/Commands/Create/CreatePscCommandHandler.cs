using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Psc;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Psc.Commands.Create
{
    public class CreatePscCommandHandler : ICreatePscCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreatePscCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
          
        }

        public async Task<object> Execute(CreatePscRequest CreatePscRequest)
        {
            if (_dataBaseService.Pscs.Where(x => x.PscsId == CreatePscRequest.PscsId).FirstOrDefault() == null)
            {
          
                var Entitymapper = _mapper.Map<Domain.Entities.Pscs.Pscs>(CreatePscRequest);
                Entitymapper.IdPscs = Guid.NewGuid();
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                _dataBaseService.Pscs.Add(Entitymapper);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, CreatePscRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Pscs Ya Registrada");
            }
        }
    }
}
