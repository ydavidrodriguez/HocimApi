using AutoMapper;
using Holcim.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application.DataBase.Proveedor.Commands.List
{
    public class GetListProveedorCommandHandler : IGetListProveedorCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetListProveedorCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<Domain.Entities.Proveedor.Proveedor>> Execute(string? nombre, string? dominio)
        {

            if (!string.IsNullOrEmpty(nombre))
            {
                return _dataBaseService.Proveedor               
                    .Where(x => x.NombreEmpresa.Contains(nombre)).ToList();
            }
            else if (!string.IsNullOrEmpty(dominio))
            {
                return _dataBaseService.Proveedor
                    .Include(x => x.Usuario)
                    .Where(x => x.Usuario.Correo.Contains(dominio)).ToList();
            }
            else if(string.IsNullOrEmpty(dominio) && string.IsNullOrEmpty(nombre)) 
            { 
                return _dataBaseService.Proveedor
                       .ToList() ;
            }
            else { return null; }

        
        }

    }
}
