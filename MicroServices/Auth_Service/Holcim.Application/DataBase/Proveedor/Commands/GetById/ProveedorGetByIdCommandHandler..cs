using AutoMapper;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Http;

namespace Holcim.Application.DataBase.Proveedor.Commands.GetById
{
    public class ProveedorGetByIdCommandHandler : IProveedorGetByIdCommandHandler
    {

        private readonly IDataBaseService _dataBaseService;
       

        public ProveedorGetByIdCommandHandler(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
          
        }

        public async Task<object> Execute(Guid IdProveedor)
        {
            var dataservice = _dataBaseService.Proveedor.Where(x => x.IdProveedor == IdProveedor);
            return ResponseApiService.Response(StatusCodes.Status201Created, dataservice);

        }

    }
}
