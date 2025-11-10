using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Proveedor.Commands.List
{
    public class ListPaisByZonaHorariaByIdCommandHandler : IListPaisByZonaHorariaByIdCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListPaisByZonaHorariaByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid PaisId)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.ZonaHorariaPais
                .Include(x=> x.ZonaHoraria)
                .Where(x => x.PaisId == PaisId).ToList());
        }

    }
}
