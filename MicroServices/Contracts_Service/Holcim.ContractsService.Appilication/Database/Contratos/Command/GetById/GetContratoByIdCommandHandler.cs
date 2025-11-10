using AutoMapper;
using Holcim.ContractsService.Appilication.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.GetById
{
    public class GetContratoByIdCommandHandler : IGetContratoByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetContratoByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute(Guid IdContrato)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Contrato.Where(x => x.IdContrato == IdContrato).First());
        }

    }
}
