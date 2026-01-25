using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.UnidadMedida;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.UnidadMedida.Commands.Update
{
    public class UpdateUnidadMedidaCommandHandler : IUpdateUnidadMedidaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateUnidadMedidaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdateUnidadMedidaRequest updateUnidadMedidaRequest)
        {

            Domain.Entities.UnidadMedida.UnidadMedida unidadMedida =  _dataBaseService.UnidadMedida.Where(x => x.IdUnidadMedida == updateUnidadMedidaRequest.IdUnidadMedida).FirstOrDefault();
            if(unidadMedida != null) 
            {
                if (_dataBaseService.UnidadMedida.Where(x=> x.UdmCode == updateUnidadMedidaRequest.UdmCode && x.IdUnidadMedida != updateUnidadMedidaRequest.IdUnidadMedida).ToList().Count == 0) 
                {
                    unidadMedida.FechaActulizacion = DateTime.Now;
                    unidadMedida.Estado = updateUnidadMedidaRequest.Estado;
                    unidadMedida.UdmCode = updateUnidadMedidaRequest.UdmCode;
                    unidadMedida.UdmDescripcion = updateUnidadMedidaRequest.UdmDescripcion;
                    unidadMedida.ColumnasExtras = updateUnidadMedidaRequest.ColumnasExtras;
                    _dataBaseService.UnidadMedida.Update(unidadMedida);
                    await _dataBaseService.SaveAsync();

                    return ResponseApiService.Response(StatusCodes.Status201Created, updateUnidadMedidaRequest);

                }
                else 
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, null,"La Unidad de Medida Ya Esta Registrada");
                }
            }
            else { return ResponseApiService.Response(StatusCodes.Status202Accepted, "Unidad Medida No Encontrada"); }
           
        }

    }
}
