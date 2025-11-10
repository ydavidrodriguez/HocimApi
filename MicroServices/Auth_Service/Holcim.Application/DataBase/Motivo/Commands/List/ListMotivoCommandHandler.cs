using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Motivo.Commands.List
{
    public class ListMotivoCommandHandler : IListMotivoCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListMotivoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute()
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Motivo.ToList());
        }

    }
}
