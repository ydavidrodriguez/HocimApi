using AutoMapper;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Proveedor;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Proveedor.Commands.Update
{
    public class UpdateProveedorCommandHandler : IUpdateProveedorCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateProveedorCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<object> Execute(UpdateProveedorRequest updateProveedorRequest,bool Directo)
        {
            Domain.Entities.Proveedor.Proveedor proveedor = _dataBaseService.Proveedor.Where(x => x.IdProveedor == updateProveedorRequest.IdProveedor).First();
            if (proveedor != null)
            {
                var proveedorepetido = _dataBaseService.Proveedor.Where(x => x.NombreEmpresa == updateProveedorRequest.NombreEmpresa && x.IdProveedor != updateProveedorRequest.IdProveedor).FirstOrDefault();

                if (proveedorepetido == null)
                {
                    proveedor.FechaActulizacion = DateTime.Now;
                    proveedor.Correo = updateProveedorRequest.Correo;
                    proveedor.Estado = updateProveedorRequest.Estado;
                    proveedor.Telefono = updateProveedorRequest.Telefono;
                    proveedor.NombreEmpresa = updateProveedorRequest.NombreEmpresa;
                    proveedor.IdiomaId = updateProveedorRequest.IdiomaId;
                    proveedor.PaisId = updateProveedorRequest.PaisId;
                    proveedor.ZonaHorariaId = updateProveedorRequest.ZonaHorariaId;
                    _dataBaseService.Proveedor.Update(proveedor);

                    if(Directo)
                    await _dataBaseService.SaveAsync();

                    return ResponseApiService.Response(StatusCodes.Status201Created, updateProveedorRequest);

                }
                else
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Proveedor Ya Existe");
                }
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Proveedor Ya Existe");

            }

        }

    }
}
