using Holcim.Application.External.Traduccion;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Pais.Commands.List
{
    public class GetListPaisAllGruCommandHandler : IGetListPaisAllGruCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IGetTraduccionService _getTraduccionService;

        public GetListPaisAllGruCommandHandler(IDataBaseService dataBaseService,
            IGetTraduccionService getTraduccionService)
        {
            _dataBaseService = dataBaseService;
            _getTraduccionService = getTraduccionService;
        }

        public async Task<object> Execute(string? leng)
        {
            return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Pais
                .Include(x => x.TipoPais)
                .Include(x => x.Region)
                .Where(x => x.TipoPais.Descripcion ==
                 EnumDomain.PaisGrud.GetEnumMemberValue().ToString())
                .Select(p => new Domain.Entities.Pais.Pais
                {
                    IdPais = p.IdPais,
                    Nombre = p.Nombre,
                    Estado = p.Estado,
                    FechaActulizacion = p.FechaActulizacion,
                    FechaCreacion = p.FechaCreacion,
                    Indicativo = p.Indicativo,
                    ColumnasExtras = p.ColumnasExtras,
                    RegionId = p.RegionId,
                    TipoPaisId = p.TipoPaisId,
                    Region = p.Region,
                    TipoPais = p.TipoPais,
                })
                .ToList()
                );
        }

    }
}
