using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Informes;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Informe.Commands.Update
{
    public class UpdateInformesCommandHandler : IUpdateInformesCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateInformesCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdateInformesRequest updateInformesRequest)
        {

            Domain.Entities.Informes.Informes informes = _dataBaseService.Informes.Where(x => x.IdInformes == updateInformesRequest.IdInformes).FirstOrDefault();
            if (informes != null)
            {
                if (_dataBaseService.Informes.Where(x => x.Nombre == updateInformesRequest.Nombre && x.IdInformes != updateInformesRequest.IdInformes).ToList().Count == 0)
                {
                    informes.FechaActulizacion = DateTime.Now;
                    informes.Estado = updateInformesRequest.Estado;
                    informes.Descripcion = updateInformesRequest.Descripcion;
                    informes.Nombre = updateInformesRequest.Nombre;
                    _dataBaseService.Informes.Update(informes);
                    await _dataBaseService.SaveAsync();

                    return ResponseApiService.Response(StatusCodes.Status201Created, updateInformesRequest);

                }
                else
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "El Informe Ya Esta Registrado");
                }
            }
            else { return ResponseApiService.Response(StatusCodes.Status202Accepted, "El Informe Ya Esta Registrado"); }

        }

    }
}
