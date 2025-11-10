using AutoMapper;
using Holcim.TaskSend.Application.External.Dapper;
using Holcim.TaskSend.Application.External.Smtp;
using Holcim.TaskSend.Domain.Models.Contratos;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Holcim.TaskSend.Application.DataBase.Contratos.Commands.SendContratos
{
    public class SendContratosCommandHandler : BackgroundService
    {
        private readonly ISmtpCommandHandler _smtpCommandHandler;
        private readonly IMapper _mapper;
        private readonly IDapperProcedure _dapperProcedure;

        public SendContratosCommandHandler(ISmtpCommandHandler smtpCommandHandler, IDapperProcedure dapperProcedure, IMapper mapper)
        {

            _smtpCommandHandler = smtpCommandHandler;
            _dapperProcedure = dapperProcedure;
            _mapper = mapper;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            try
            {

                Console.WriteLine("Tarea en segundo plano iniciada.");

                while (!stoppingToken.IsCancellationRequested)
                {

                    //var ParametersListReplyProvider = new { IDESTADO = rfxid };
                    var listrfxrespuestaPreguntaRfxId = _dapperProcedure.GetQuery(null, "GETCONTRACTBYSTATEPENDIGASSSING");
                    List<GetContratosPending> Contratospentientesflujo = JsonConvert.DeserializeObject<List<GetContratosPending>>(listrfxrespuestaPreguntaRfxId);

                    if (Contratospentientesflujo != null)
                    {
                        foreach (var response in Contratospentientesflujo)
                        {
                            var contractresponse = new { VALORCONTRATO = response.Monto, REGIONID = response.RegionId, TipoContratoId = response.IdTipoContrato };
                            var listflujoaprobacion = _dapperProcedure.GetQuery(contractresponse, "GETAPPROVALFLOW");
                            List<GetFlujosGnerados> flujosGenerados = JsonConvert.DeserializeObject<List<GetFlujosGnerados>>(listflujoaprobacion);

                            if (flujosGenerados != null)
                            {
                                foreach (var flujospro in flujosGenerados)
                                {
                                    var contractflujosparameters = new { FlujoAprobacionId = flujospro.IdFlujoAprobacion, ContratoId = response.IdContrato };
                                    int rowsCreateflujoaprobacion = _dapperProcedure.InsertQuery(contractflujosparameters, "CREATEFLOWCONTRACT");
                                    if (rowsCreateflujoaprobacion > 0)
                                    {
                                        Console.WriteLine("Flujo asociado al contrado");
                                    }
                                }
                            }

                        }

                    }
                    await Task.Delay(TimeSpan.FromHours(13), stoppingToken);
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
