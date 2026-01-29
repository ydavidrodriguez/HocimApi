using Holcim.Application.External.Traduccion;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Pais.Commands.List
{
    public class ListPaisCommandHandler : IListPaisCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IGetTraduccionService _getTraduccionService;

        public ListPaisCommandHandler(IDataBaseService dataBaseService,
            IGetTraduccionService getTraduccionService)
        {
            _dataBaseService = dataBaseService;
            _getTraduccionService = getTraduccionService;
        }

        public async Task<object> Execute(string? nombre, string leng)
        {

            var query = _dataBaseService.Pais.Include(x => x.Region)
             .Include(x => x.TipoPais)
             .Include(x => x.Region)
             .Where(x => (string.IsNullOrEmpty(nombre) || x.Nombre.Contains(nombre)
              && x.TipoPais.Descripcion == EnumDomain.PaisProveedor.GetEnumMemberValue().ToString())
              && (!string.IsNullOrEmpty(nombre) ||
              x.TipoPais.Descripcion == EnumDomain.PaisProveedor.GetEnumMemberValue().ToString()))
             .Select(p => new Domain.Entities.Pais.Pais
             {
                 IdPais = p.IdPais,
                 Nombre =p.Nombre,
                 Estado = p.Estado,
                 FechaActulizacion = p.FechaActulizacion,
                 FechaCreacion = p.FechaCreacion,
                 Indicativo = p.Indicativo,
                 ColumnasExtras = p.ColumnasExtras,
                 RegionId = p.RegionId,
                 TipoPaisId = p.TipoPaisId,
                 Region = p.Region,
                 TipoPais = p.TipoPais,
             }).ToList();

            return ResponseApiService.Response(StatusCodes.Status201Created, query);
        }

    }
}
