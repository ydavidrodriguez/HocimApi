using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.UnidadMedida.Commands.List
{
    public class ListUnidadMedidaCommandHandler : IListUnidadMedidaCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListUnidadMedidaCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(string? UdmCode)
        {
             List<Domain.Entities.UnidadMedida.UnidadMedida> ObjUnidadMedida = new List<Domain.Entities.UnidadMedida.UnidadMedida>();

            if (!string.IsNullOrEmpty(UdmCode)) 
            {
                
                ObjUnidadMedida = _dataBaseService.UnidadMedida.Where(x => x.UdmCode.Contains(UdmCode)).ToList();
            }
            else
            {
                ObjUnidadMedida = _dataBaseService.UnidadMedida.ToList();
            }

            return ResponseApiService.Response(StatusCodes.Status201Created, ObjUnidadMedida);


        }

    }
}
