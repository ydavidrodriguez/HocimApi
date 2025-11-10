using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Informes;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.InformesRol.Update
{
    public class UpdateInformesRolCommandHandler : IUpdateInformesRolCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateInformesRolCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdateInformesRolRequest updateInformesRolRequest)
        {

            Domain.Entities.Informes.InformesRol informesRol = _dataBaseService.InformesRol.Where(x => x.IdInformesRol == updateInformesRolRequest.IdInformesRol).FirstOrDefault();
            if (informesRol != null)
            {
                if (_dataBaseService.InformesRol.Where(x => x.InformesId == updateInformesRolRequest.InformesId && x.RolId == updateInformesRolRequest.RolId).ToList().Count == 0)

                {
                    informesRol.InformesId = updateInformesRolRequest.InformesId;
                    informesRol.RolId = updateInformesRolRequest.RolId;
                    _dataBaseService.InformesRol.Update(informesRol);
                    await _dataBaseService.SaveAsync();

                    return ResponseApiService.Response(StatusCodes.Status201Created, updateInformesRolRequest);

                }
                else
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "El rol ya tiene ese informe asociado");
                }
            }
            else { return ResponseApiService.Response(StatusCodes.Status202Accepted, "El rol ya tiene ese informe asociado"); }

        }

    }
}
