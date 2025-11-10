using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Informes;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Informe.Commands.Create
{
    public class CreateInformesCommandHandler : ICreateInformesCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateInformesCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(CreateInformesRequest createInformesRequest)
        {

            if (_dataBaseService.Informes.Where(x => x.Nombre == createInformesRequest.Nombre).FirstOrDefault() == null)
            {
                var Entitymapper = _mapper.Map<Domain.Entities.Informes.Informes>(createInformesRequest);
                Entitymapper.IdInformes = Guid.NewGuid();
                Entitymapper.Estado = true;
                Entitymapper.FechaCreacion = DateTime.Now;
                Entitymapper.FechaActulizacion = DateTime.Now;
                _dataBaseService.Informes.Add(Entitymapper);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, createInformesRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Informes Ya Registrado");
            }

        }

    }
}
