using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Psc.Grupo.List
{
    public class GetListGrupoPscCommandHandler : IGetListGrupoPscCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetListGrupoPscCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute()
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.GrupoPsc.ToList());
        }


    }
}
