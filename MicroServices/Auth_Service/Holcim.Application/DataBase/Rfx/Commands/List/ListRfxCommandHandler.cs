using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Rfx.Commands.List
{
    public class ListRfxCommandHandler : IListRfxCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListRfxCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(string? Nombre, Guid? EstadoId, bool? Gestion)
        {

            var EstadosPrueba = new[] { "Borrador", "Plantilla", "Prueba" };

            var listrfx = _dataBaseService.Rfx
                     .Include(x => x.TipoRfx)
                     .Include(x => x.Estado)
                     .Include(x => x.Moneda)
                     .Where(x =>
                            // Filtro por Nombre: si Nombre no es null o vacío, se filtra por coincidencia
                            (string.IsNullOrEmpty(Nombre) || x.Nombre.Contains(Nombre)) &&

                            // Filtro por EstadoId: si EstadoId tiene valor, se filtra por EstadoId
                            (!EstadoId.HasValue || x.EstadoId == EstadoId) &&

                            // Filtro por Gestion: si Gestion es null, no aplica, si es false, no se excluyen los estados de prueba, si es true, se excluyen
                            (!Gestion.HasValue ||
                             (Gestion.Value == false || !EstadosPrueba.Contains(x.Estado.Nombre.Trim())))
                        )
                     .Select(x => new Domain.Models.Rfx.rfxAll
                     {
                         IdRfx = x.IdRfx,
                         Consecutivo = x.Consecutivo,
                         Detalle = x.Detalle,
                         Estado = x.Estado,
                         EstadoId = x.EstadoId,
                         FechaActulizacion = x.FechaActulizacion,
                         FechaCreacion = x.FechaCreacion,
                         FechaFinal = x.FechaFinal,
                         FechaInicial = x.FechaInicial,
                         Moneda = x.Moneda,
                         MonedaId = x.MonedaId,
                         Nombre = x.Nombre,
                         Prueba = x.Prueba,
                         TipoRfx = x.TipoRfx,
                         TipoRfxId = x.TipoRfxId,
                         UsuarioCreacion = x.UsuarioCreacion,
                         UsuarioCreacionNombre = _dataBaseService.Usuario.Where(c => c.IdUsuario == x.UsuarioCreacion).FirstOrDefault().Nombre + " " + _dataBaseService.Usuario.Where(c => c.IdUsuario == x.UsuarioCreacion).FirstOrDefault().Apellido,
                         ValorReferencia = x.ValorReferencia,
                         Sitio = x.Sitio,
                         DireccionEntrega = x.DireccionEntrega
                     })
                     .OrderByDescending(x => x.FechaCreacion)
                     .ToList();


            var rfxtermporal = _dataBaseService.RfxTemporal.ToList();

            return ResponseApiService.Response(StatusCodes.Status201Created, listrfx);
        }


    }
}
