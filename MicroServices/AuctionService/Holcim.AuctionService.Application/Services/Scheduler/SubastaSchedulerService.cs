using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Holcim.AuctionService.Application.Services
{
    public class SubastaSchedulerService : ISubastaSchedulerService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IDataBaseService _dataBaseService;
        private readonly ISchedulerFactory _schedulerFactory;

        public SubastaSchedulerService(
            IServiceScopeFactory serviceScopeFactory,
            IDataBaseService dataBaseService,
            ISchedulerFactory schedulerFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _dataBaseService = dataBaseService;
            _schedulerFactory = schedulerFactory;
        }

        public async Task ProgramarSubastaAsync(
            ConfiguracionSubastaInglesa config,
            DateTime horaInicio,
            DateTime horaFin)
        {
            //var scheduler = await _schedulerFactory.GetScheduler();

            //var jobIdInicio = $"subasta-{config.SubastaId}-inicio";
            //var jobKeyInicio = new JobKey(jobIdInicio, "SubastaJobs");

            //var jobInicio = JobBuilder.Create<Holcim.AuctionService.Application.Services.QuartzJobs.CambiarEstadoSubastaJob>()
            //    .WithIdentity(jobKeyInicio)
            //    .UsingJobData("SubastaId", config.SubastaId)
            //    .UsingJobData("NuevoEstado", "En Curso")
            //    .Build();

            //var triggerInicio = TriggerBuilder.Create()
            //    .WithIdentity($"{jobIdInicio}-trigger", "SubastaTriggers")
            //    .StartAt(horaInicio)
            //    .Build();

            //var jobIdFin = $"subasta-{config.SubastaId}-fin";
            //var jobKeyFin = new JobKey(jobIdFin, "SubastaJobs");

            //var jobFin = JobBuilder.Create<Holcim.AuctionService.Application.Services.QuartzJobs.CambiarEstadoSubastaJob>()
            //    .WithIdentity(jobKeyFin)
            //    .UsingJobData("SubastaId", config.SubastaId)
            //    .UsingJobData("NuevoEstado", "Finalizado")
            //    .Build();

            //var triggerFin = TriggerBuilder.Create()
            //    .WithIdentity($"{jobIdFin}-trigger", "SubastaTriggers")
            //    .StartAt(horaFin)
            //    .Build();

            //if (horaInicio >= DateTime.UtcNow)
            //    {
            //        await scheduler.ScheduleJob(jobInicio, triggerInicio);
            //        config.JobIdInicio = jobIdInicio;
            //    }

            //    if (horaFin >= DateTime.UtcNow)
            //    {
            //        await scheduler.ScheduleJob(jobFin, triggerFin);
            //        config.JobIdFin = jobIdFin;
            //    }

            await _dataBaseService.SaveAsync();
        }

        public async Task ActualizarSubastaAsync(Guid subastaId, DateTime nuevaHoraInicio, DateTime nuevaHoraFin)
        {
            //var config = await _dataBaseService.ConfiguracionSubastaInglesa
            //    .FirstOrDefaultAsync(c => c.SubastaId == subastaId);

            //if (config != null)
            //{
            //    await CancelarTarea(config.JobIdInicio);
            //    await CancelarTarea(config.JobIdFin);

            //    var scheduler = await _schedulerFactory.GetScheduler();

            //    var jobIdInicio = $"subasta-{subastaId}-inicio";
            //    var jobKeyInicio = new JobKey(jobIdInicio, "SubastaJobs");
            //    var jobInicio = JobBuilder.Create<Holcim.AuctionService.Application.Services.QuartzJobs.CambiarEstadoSubastaJob>()
            //        .WithIdentity(jobKeyInicio)
            //        .UsingJobData("SubastaId", subastaId)
            //        .UsingJobData("NuevoEstado", "En Curso")
            //        .Build();
            //    var triggerInicio = TriggerBuilder.Create()
            //        .WithIdentity($"{jobIdInicio}-trigger", "SubastaTriggers")
            //        .StartAt(nuevaHoraInicio)
            //        .Build();
            //    if (nuevaHoraInicio >= DateTime.UtcNow)
            //    {
            //        await scheduler.ScheduleJob(jobInicio, triggerInicio);
            //        config.JobIdInicio = jobIdInicio;
            //    }

            //    var jobIdFin = $"subasta-{subastaId}-fin";
            //    var jobKeyFin = new JobKey(jobIdFin, "SubastaJobs");
            //    var jobFin = JobBuilder.Create<Holcim.AuctionService.Application.Services.QuartzJobs.CambiarEstadoSubastaJob>()
            //        .WithIdentity(jobKeyFin)
            //        .UsingJobData("SubastaId", subastaId)
            //        .UsingJobData("NuevoEstado", "Finalizado")
            //        .Build();
            //    var triggerFin = TriggerBuilder.Create()
            //        .WithIdentity($"{jobIdFin}-trigger", "SubastaTriggers")
            //        .StartAt(nuevaHoraFin)
            //        .Build();
            //    if (nuevaHoraFin >= DateTime.UtcNow)
            //    {
            //        await scheduler.ScheduleJob(jobFin, triggerFin);
            //        config.JobIdFin = jobIdFin;
            //    }


            //    await _dataBaseService.SaveAsync();
            //}

        }

        public async Task CancelarSubastaAsync(Guid subastaId)
        {
            //var config = await _dataBaseService.ConfiguracionSubastaInglesa
            //    .FirstOrDefaultAsync(c => c.SubastaId == subastaId);

            //if (config != null)
            //{
            //    await CancelarTarea(config.JobIdInicio);
            //    await CancelarTarea(config.JobIdFin);

            //    config.JobIdInicio = null;
            //    config.JobIdFin = null;

            //    await _dataBaseService.SaveAsync();
            //}
        }

        //private async Task CancelarTarea(string? jobId)
        //{
        //    if (string.IsNullOrWhiteSpace(jobId)) return;

        //    var scheduler = await _schedulerFactory.GetScheduler();

        //    var jobKey = new JobKey(jobId, "SubastaJobs");
        //    await scheduler.DeleteJob(jobKey);
        //}

    }
}
