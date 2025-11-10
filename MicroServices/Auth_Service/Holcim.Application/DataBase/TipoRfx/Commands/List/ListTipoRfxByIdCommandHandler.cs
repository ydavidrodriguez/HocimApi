using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.TipoRfx.Commands.List
{
    public class ListTipoRfxByIdCommandHandler : IListTipoRfxByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListTipoRfxByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid Id)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.TipoRfx.Where(x=> x.IdTipoRfx == Id).FirstOrDefault());
        }


    }
}
