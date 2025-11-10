using Holcim.ContractsService.Domain.Entities.Aprobaciones;
using Holcim.ContractsService.Domain.Entities.Contratos;
using Holcim.ContractsService.Domain.Entities.FlujoAprobacion;
using Holcim.ContractsService.Domain.Entities.FlujoContrato;
using Holcim.ContractsService.Domain.Entities.Pasos;
using Microsoft.EntityFrameworkCore;

namespace Holcim.ContractsService.Appilication
{
    public interface IDataBaseService
    {

        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<TipoContrato> TipoContrato { get; set; }
        public DbSet<FlujoAprobacion> FlujoAprobacion { get; set; }
        public DbSet<PasoFlujo> PasoFlujo { get; set; }
        public DbSet<PasosPerfiles> PasosPerfiles { get; set; }
        public DbSet<PasosTipoContrato> PasosTipoContrato { get; set; }
        public DbSet<FlujoContrato> FlujoContrato { get; set; }
        public DbSet<AprobacionPasoFlujo> AprobacionPasoFlujo { get; set; }
        Task<bool> SaveAsync();

    }
}
