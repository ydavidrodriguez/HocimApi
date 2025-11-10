using Holcim.DocumetsService.Application;
using Microsoft.EntityFrameworkCore;

namespace Holcim.DocumetsService.Persistence.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {

        public DataBaseService(DbContextOptions<DataBaseService> options) : base(options)
        {

        }
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
            //new RespuestaPreguntaConfiguration(modelBuilder.Entity<RespuestaPregunta>());
        }


    }
}
