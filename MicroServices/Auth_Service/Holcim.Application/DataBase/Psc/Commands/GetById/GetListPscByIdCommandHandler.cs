using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Psc.Commands.GetById
{
    public class GetListPscByIdCommandHandler : IGetListPscByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetListPscByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid IdPsc)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Pscs.Where(x => x.IdPscs == IdPsc));
        }

    }
}
