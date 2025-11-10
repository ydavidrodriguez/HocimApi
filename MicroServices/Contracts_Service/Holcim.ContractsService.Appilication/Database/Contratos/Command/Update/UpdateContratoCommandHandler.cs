using AutoMapper;
using Holcim.ContractsService.Appilication.External;
using Holcim.ContractsService.Appilication.Feature;
using Holcim.ContractsService.Domain.Models.Contrato;
using Microsoft.AspNetCore.Http;

namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.Update
{
    public class UpdateContratoCommandHandler : IUpdateContratoCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly IDataBaseService _dataBaseService;

        public UpdateContratoCommandHandler(IMapper mapper, IDapperProcedure dapperProcedure, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dapperProcedure = dapperProcedure;
            _dataBaseService = dataBaseService;
        }
        public async Task<object> Execute(PutContratoUpdateRequest putContratoUpdateRequest)
        {
             var contratoupdate =  _dataBaseService.Contrato.Where(x => x.IdContrato == putContratoUpdateRequest.IdContrato).FirstOrDefault();
            if (contratoupdate != null)
            {
                contratoupdate.FechaActulizacion = DateTime.Now;
                contratoupdate.Descripcion = putContratoUpdateRequest?.Descripcion;
                contratoupdate.EstadoId = putContratoUpdateRequest.EstadoId;
                contratoupdate.MonedaId = putContratoUpdateRequest.MonedaId;
                contratoupdate.Monto = putContratoUpdateRequest.Monto;
                contratoupdate.Nombre = putContratoUpdateRequest.Nombre;    
                contratoupdate.PaisId = putContratoUpdateRequest.PaisId;
                contratoupdate.ProveedorId = putContratoUpdateRequest.ProveedorId;
                contratoupdate.RegionId = putContratoUpdateRequest.RegionId;
                contratoupdate.TipoContratoId = putContratoUpdateRequest.TipoContratoId;

                _dataBaseService.Contrato.Update(contratoupdate);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, putContratoUpdateRequest);

            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, "Contrato no encontrado");
            }

        }

    }
}
