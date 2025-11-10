using AutoMapper;
using Holcim.ContractsService.Appilication.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.ContractsService.Appilication.Database.Contratos.TipoContrato.Commands.List
{
    public class GetListTipoContratoCommandHandler : IGetListTipoContratoCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetListTipoContratoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;

        }

        public async Task<object> Execute()
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.TipoContrato.ToList());
        }
    }
}
