using Holcim.Provider.Application;
using Holcim.Provider.Domain.Entities;
using Holcim.Provider.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Provider.Persistence.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions<DataBaseService> options) : base(options)
        {

        }

        public DbSet<RespuestaPregunta> RespuestaPregunta { get; set; }
        public DbSet<ProveedorUsuario> ProveedorUsuario { get; set; }
        public DbSet<RespuestaPreguntaPorcentaje> RespuestaPreguntaPorcentaje { get; set; }

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
            new RespuestaPreguntaConfiguration(modelBuilder.Entity<RespuestaPregunta>());
            new ProveedorUsuarioConfiguration(modelBuilder.Entity<ProveedorUsuario>());
            new RespuestaPreguntaProcentajeConfiguration(modelBuilder.Entity<RespuestaPreguntaPorcentaje>());
        }
    }
}
