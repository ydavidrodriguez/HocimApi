using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Informes;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.InformesRol.Create
{
    public class CreateInformesRolCommandHandler : ICreateInformesRolCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateInformesRolCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(List<CreateInformesRolRequest> createInformesRequest)
        {

            foreach (var request in createInformesRequest)
            {
                foreach (Guid RolList in request.RolId)
                {
                    if (_dataBaseService.InformesRol.Where(x => x.InformesId == request.InformesId && x.RolId == RolList).FirstOrDefault() == null)
                    {
                        Domain.Entities.Informes.InformesRol informesRol = new Domain.Entities.Informes.InformesRol();

                        informesRol.IdInformesRol = Guid.NewGuid();
                        informesRol.InformesId = request.InformesId;
                        informesRol.RolId = RolList;

                        _dataBaseService.InformesRol.Add(informesRol);
                        await _dataBaseService.SaveAsync();

                        return ResponseApiService.Response(StatusCodes.Status201Created, createInformesRequest);

                    }
                    else
                    {
                        return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "El rol Ya tiene ese Informe Asociado");
                    }

                }

            }
            return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "No enviaste Roles para Asociar");

        }

    }
}
