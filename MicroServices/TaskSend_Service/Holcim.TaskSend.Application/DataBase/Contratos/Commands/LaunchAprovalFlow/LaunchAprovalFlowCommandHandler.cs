using AutoMapper;
using Holcim.TaskSend.Application.DataBase.Correo;
using Holcim.TaskSend.Application.External.Dapper;
using Holcim.TaskSend.Domain.Models.Contratos;
using Holcim.TaskSend.Domain.Models.Email;
using Holcim.TaskSend.Domian.Models.Email;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Holcim.TaskSend.Application.DataBase.Contratos.Commands.LaunchAprovalFlow
{
    public class LaunchAprovalFlowCommandHandler : BackgroundService
    {

        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;
        private readonly ICreateCorreoCommandHandler _createCorreoCommandHandler;

        public LaunchAprovalFlowCommandHandler(IDapperProcedure dapperProcedure, IMapper mapper, ICreateCorreoCommandHandler createCorreoCommandHandler)
        {

            _dapperProcedure = dapperProcedure;
            _mapper = mapper;
            _createCorreoCommandHandler = createCorreoCommandHandler;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            try
            {

                Console.WriteLine("Tarea en segundo plano iniciada.");

                while (!stoppingToken.IsCancellationRequested)
                {

                    //var ParametersListReplyProvider = new { IDESTADO = rfxid };
                    var listrFlujoAprobacionParaLanzar = _dapperProcedure.GetQuery(null, "GETFLOWCONTRACTEARRINGFLOW");
                    List<GetFlujoUserAprobacion> flujaprobacionesparalanzar = JsonConvert.DeserializeObject<List<GetFlujoUserAprobacion>>(listrFlujoAprobacionParaLanzar);

                    if (flujaprobacionesparalanzar != null)
                    {
                        foreach (var response in flujaprobacionesparalanzar)
                        {
                            var parametersEmail = new { DESCRIPCION = "InvitacionProbacion" };
                            var CorreoHtml = _dapperProcedure.GetQuery(parametersEmail, "GETEMAILHTML");
                            List<GetCorreoEmail> GetHtmlCorreo = JsonConvert.DeserializeObject<List<GetCorreoEmail>>(CorreoHtml);

                            CreateEmailRequest createEmailRequest = new CreateEmailRequest();

                            string Replace = GetHtmlCorreo[0].Html.Replace("\"", "'").ToString();

                            string Htmlfinal = string.Format(Replace, response.Nombre);

                            createEmailRequest.Remitente = "";
                            createEmailRequest.Asunto = "Aprobacion  Contrato";
                            createEmailRequest.Destinatarios = new List<string> { response.Correo };
                            createEmailRequest.Body = Htmlfinal;

                            await _createCorreoCommandHandler.Execute(createEmailRequest);

                        }

                    }
                    await Task.Delay(TimeSpan.FromHours(25), stoppingToken);
                    Console.WriteLine("Tarea en segundo plano detenida.");

                }
            }
            catch (System.Exception ex)
            {

                Console.WriteLine("Error Tarea en segundo plano" + ex.Message.ToString());
            }

        }


    }
}
