using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Entities.Enums;
using Holcim.Domain.Entities.Estado;
using Microsoft.AspNetCore.Http;
using System.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Holcim.Application.DataBase.Rol.Commands.List
{
    public class ListRolCommandHandler : IListRolCommandHandler
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public ListRolCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(Guid? RolId)
        {
            if (RolId != null) 
            {
                var roluser = _dataBaseService.Rol.Where(x => x.IdRol == RolId).FirstOrDefault().Nombre;
                if (!string.IsNullOrEmpty(roluser))
                {
                    var roles = roluser == "Administrador Sistema"
                       ? new[] { "Administrador Sistema", "Administrador Global", "Administrador Regional", "Comprador", "Auditor" }
                       : (roluser == "Administrador Global")
                           ? new[] { "Administrador Global", "Administrador Regional", "Comprador", "Auditor" }
                           : (roluser == "Administrador Regional")
                               ? new[] { "Administrador Regional", "Comprador" }
                               : new[] { "Rol por defecto" };


                    var rol = _dataBaseService.Rol.Where(x => x.Nombre != EnumDomain.RolProveedor.GetEnumMemberValue() 
                    && roles.Contains(x.Nombre)).ToList();

                    return ResponseApiService.Response(StatusCodes.Status201Created, rol);

                }
                else 
                {
                    return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Rol.ToList());
                }
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status201Created, _dataBaseService.Rol.ToList());
            }
            
        }

    }
}
