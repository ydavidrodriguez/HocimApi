using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Rfx.Commands.GettraceabilityRfx
{
    public class GettraceabilityRfx : IGettraceabilityRfx
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GettraceabilityRfx(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid IdRfx)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created,
                _dataBaseService.TrazabilidadRfx.Include(x=> x.Usuario).Include(x=> x.Estado)  
                .Where(x => x.RfxId == IdRfx).ToList());
        }

    }
}
