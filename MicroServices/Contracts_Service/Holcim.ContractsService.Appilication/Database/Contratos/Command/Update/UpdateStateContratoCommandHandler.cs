using AutoMapper;
using Holcim.ContractsService.Appilication.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.Update
{
    public class UpdateStateContratoCommandHandler : IUpdateStateContratoCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
      

        public UpdateStateContratoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid Estadoid, Guid IdContrato)
        {
            Domain.Entities.Contratos.Contrato contrato =  _dataBaseService.Contrato.Where(x => x.IdContrato == IdContrato).FirstOrDefault();
            if (contrato != null)
            { 
                contrato.EstadoId = Estadoid;

                _dataBaseService.Contrato.Update(contrato);
                await _dataBaseService.SaveAsync();

                return ResponseApiService.Response(StatusCodes.Status201Created, IdContrato);
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, "Contrato No Encontrado", "Contrato No Encontrado");
            }
            
        }
    }
}
