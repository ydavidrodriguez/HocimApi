using AutoMapper;
using Holcim.ContractsService.Appilication.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.ContractsService.Appilication.Database.Contratos.Command.List
{
    public class GetListContratoCommandHandler : IGetListContratoCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetListContratoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute()
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Contrato.Include(x=> x.TipoContrato).ToList());
        }

    }
}
