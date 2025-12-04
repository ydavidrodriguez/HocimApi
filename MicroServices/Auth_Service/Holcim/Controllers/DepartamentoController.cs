using Holcim.Application.DataBase.Cargo.Commands.List;
using Holcim.Application.DataBase.Departamento;
using Holcim.Application.Exception;
using Holcim.Application.Feature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DepartamentoController : ControllerBase
    {
        [HttpGet("GetListDepartamentoAll")]
        public async Task<IActionResult> GetListDepartamentoAll(
         [FromServices] IListDepartamentoCommandHandler ListDepartamentoCommandHandler)
        {
            var data = await ListDepartamentoCommandHandler.Execute();
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));

        }
    }
}
