using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Psc.Commands.List
{
    public class GetListPscCommandHandler : IGetListPscCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetListPscCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(string? Codigo)
        {
            if (string.IsNullOrEmpty(Codigo)) 
            {
                var dataservice = _dataBaseService.Pscs.Include(x=> x.CategoriaPsc).Include(x=> x.GrupoPsc).ToList();
                return ResponseApiService.Response(StatusCodes.Status201Created, dataservice);
            }
            else 
            {
                var dataservice = _dataBaseService.Pscs.Include(x => x.CategoriaPsc).Include(x => x.GrupoPsc).Where(x=>x.PscsId.Contains(Codigo)).ToList();
                return ResponseApiService.Response(StatusCodes.Status201Created, dataservice);

            }

        }

    }
}
