using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Pais.Commands.List
{
    public class ListPaisByIdCommandHandler : IListPaisByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListPaisByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid PaisId)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Pais
                .Include(x => x.Region)
                .Where(x => x.IdPais == PaisId).ToList());
        }

    }
}
