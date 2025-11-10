using Holcim.TaskSend.Application.Enums.SPEnums;
using Holcim.TaskSend.Application.External.Dapper;
using Holcim.TaskSend.Domain.Models.Subasta;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Holcim.TaskSend.Application.DataBase.Subasta.Commands.UpdateStateSubasta
{
    public class UpdateStateSubastaCommandHandler : BackgroundService
    {


        private readonly IDapperProcedure _dapperProcedure;


        public UpdateStateSubastaCommandHandler(IDapperProcedure dapperProcedure)
        {
            _dapperProcedure = dapperProcedure;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            try
            {
                Console.WriteLine("Tarea en segundo plano iniciada.");
                while (!stoppingToken.IsCancellationRequested)
                {
                    //var ParametersListReplyProvider = new { IDESTADO = rfxid };
                    var listPendientesSubasta = _dapperProcedure.GetQuery(null, EnumSp.GETSTATEPENDINGAPRROVE.GetEnumMemberValue());
                    List<GetSubastaPendiente> PendientesSubasta =
                        JsonConvert.DeserializeObject<List<GetSubastaPendiente>>(listPendientesSubasta);

                    if (PendientesSubasta != null)
                    {
                        foreach (var response in PendientesSubasta)
                        {
                            DateTime fechaActualUtc = DateTime.UtcNow;
                            fechaActualUtc.AddSeconds(-fechaActualUtc.Second).AddMilliseconds(-fechaActualUtc.Millisecond);
                            response.FechaInicio.Value.AddSeconds(-response.FechaInicio.Value.Second)
                                .AddMilliseconds(-response.FechaInicio.Value.Millisecond);

                            if (response.FechaInicio <= fechaActualUtc)
                            {
                                var parameters = new { SubastaId = response.IdSubasta };
                                _dapperProcedure.UpdateQuery(parameters,
                                    EnumSp.POSTUPDATEUACTIONSTATE.GetEnumMemberValue());
                            }
                        }
                    }
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
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
