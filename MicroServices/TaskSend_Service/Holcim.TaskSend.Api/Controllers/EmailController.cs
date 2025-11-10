using Holcim.TaskSend.Application.DataBase.Email.Commands.Create;
using Holcim.TaskSend.Application.DataBase.Email.Commands.SendEmail;
using Holcim.TaskSend.Application.Exception;
using Holcim.TaskSend.Domian.Models.Email;
using Microsoft.AspNetCore.Mvc;

namespace Holcim.TaskSend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [TypeFilter(typeof(ExceptionManager))]
    public class EmailController : ControllerBase
    {
        [HttpGet("GetSendUnidadMedida")]
        public async Task<IActionResult> GetSendUnidadMedida(
        [FromServices] ISendEmailCommandHandler SendEmailCommandHandler)
        {
            return Ok(await SendEmailCommandHandler.Execute());

        }



    }
}
