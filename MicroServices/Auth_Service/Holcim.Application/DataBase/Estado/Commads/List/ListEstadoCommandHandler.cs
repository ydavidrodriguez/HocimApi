using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Estado.Commads.List
{
    public class ListEstadoCommandHandler : IListEstadoCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListEstadoCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(string? Nombre, string? TipoEstado,Guid? EstadoId)
        {
            var datos = 
                _dataBaseService.Estado
                .Include(x=> x.TipoEstado)
                .Where( x=>  
                (string.IsNullOrEmpty(Nombre) || x.Nombre.Trim() == Nombre.Trim()) &&
                (string.IsNullOrEmpty(TipoEstado) || x.TipoEstado.Descripcion == TipoEstado) &&
                (EstadoId == null || x.IdEstado == EstadoId )

                )
                .ToList();

            return ResponseApiService.Response(StatusCodes.Status201Created, datos
                );
        }

    }
}
