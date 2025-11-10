using Holcim.ContractsService.Appilication;
using Holcim.ContractsService.Domain.Entities.Aprobaciones;
using Holcim.ContractsService.Domain.Entities.Contratos;
using Holcim.ContractsService.Domain.Entities.FlujoAprobacion;
using Holcim.ContractsService.Domain.Entities.FlujoContrato;
using Holcim.ContractsService.Domain.Entities.Pasos;
using Holcim.ContractsService.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Holcim.ContractsService.Persistence.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {

        public DataBaseService(DbContextOptions<DataBaseService> options) : base(options)
        {


        }

        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<TipoContrato> TipoContrato { get; set; }
        public DbSet<FlujoAprobacion> FlujoAprobacion { get; set; }
        public DbSet<PasoFlujo> PasoFlujo { get; set; }
        public DbSet<PasosPerfiles> PasosPerfiles { get; set; }
        public DbSet<PasosTipoContrato> PasosTipoContrato { get; set; }
        public DbSet<FlujoContrato> FlujoContrato { get; set; }
        public DbSet<AprobacionPasoFlujo> AprobacionPasoFlujo { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }

        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            new ContratoConfiguration(modelBuilder.Entity<Contrato>());
            new TipoContratoConfiguration(modelBuilder.Entity<TipoContrato>());
            new FlujoAprobacionConfiguration(modelBuilder.Entity<FlujoAprobacion>());
            new PasoFlujoConfiguration(modelBuilder.Entity<PasoFlujo>());
            new PasosPerfilesConfiguration(modelBuilder.Entity<PasosPerfiles>());
            new PasosTipoContratoConfiguration(modelBuilder.Entity<PasosTipoContrato>());
            new FlujoContratoConfiguration(modelBuilder.Entity<FlujoContrato>());
            new AprobacionPasoFlujoConfiguration(modelBuilder.Entity<AprobacionPasoFlujo>());

        }

    }

}
