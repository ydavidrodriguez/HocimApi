using Holcim.Application.DataBase.Proveedor.Commands.Create;
using Holcim.Application.DataBase.Proveedor.Commands.GetById;
using Holcim.Application.DataBase.Proveedor.Commands.List;
using Holcim.Application.DataBase.Proveedor.Commands.Update;
using Holcim.Application.Exception;
using Holcim.Application.Feature;
using Holcim.Domain.Models.Proveedor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ProveedorController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("PostCreateProveedor")]
        public async Task<IActionResult> PostCreateProveedor(
         [FromServices] ICreateProveedorCommandHandler CreateProveedorCommandHandler, [FromBody] CreatProveedorRequest CreateUsuarioRequest)
        {
            return Ok(await CreateProveedorCommandHandler.Execute(CreateUsuarioRequest));
        }

        [HttpGet("GetListProveedor")]
        public async Task<IActionResult> GetListProveedor(
        [FromServices] IGetListProveedorCommandHandler GetListProveedorCommandHandler, [FromQuery] string? Nombre, [FromQuery] string? dominio)
        {
            var data = await GetListProveedorCommandHandler.Execute(Nombre, dominio);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));

        }

        [HttpPut("PutUpdateProveedor")]
        public async Task<IActionResult> PutUpdateProveedor(
        [FromServices] IUpdateProveedorCommandHandler UpdateProveedorCommandHandler, [FromBody] UpdateProveedorRequest updateProveedorRequest)
        {
            return Ok(await UpdateProveedorCommandHandler.Execute(updateProveedorRequest,true));
        }

        [HttpGet("GetProveedorById")]
        public async Task<IActionResult> GetProveedorById(
        [FromServices] IProveedorGetByIdCommandHandler ProveedorGetByIdCommandHandler, [FromQuery] Guid IdProveedor)
        {
            return Ok(await ProveedorGetByIdCommandHandler.Execute(IdProveedor));
        }
    
    }
}

