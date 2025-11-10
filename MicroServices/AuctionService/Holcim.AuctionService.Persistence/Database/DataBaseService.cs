using Holcim.AuctionService.Application;
using Holcim.AuctionService.Domain.Entities.Correo;
using Holcim.AuctionService.Domain.Entities.Estado;
using Holcim.AuctionService.Domain.Entities.GanadorSubasta;
using Holcim.AuctionService.Domain.Entities.ItemSubasta;
using Holcim.AuctionService.Domain.Entities.Mensaje;
using Holcim.AuctionService.Domain.Entities.ProveedorSubasta;
using Holcim.AuctionService.Domain.Entities.Region;
using Holcim.AuctionService.Domain.Entities.Ronda;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Holcim.AuctionService.Domain.Entities.Usuario;
using Holcim.AuctionService.Domain.Entities.ZonaHoraria;
using Holcim.AuctionService.Persistence.Configuration;
using Holcim.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Holcim.AuctionService.Persistence.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions<DataBaseService> options) : base(options)
        {


        }

        public DbSet<ItemSubasta> ItemSubasta { get; set; }
        public DbSet<GanadorSubasta> GanadorSubasta { get; set; }
        public DbSet<PaisSubasta> PaisSubasta { get; set; }
        public DbSet<Subasta> Subasta { get; set; }
        public DbSet<SubastaTemporal> SubastaTemporal { get; set; }
        public DbSet<TipoSubasta> TipoSubasta { get; set; }
        public DbSet<Correo> Correo { get; set; }
        public DbSet<InvitacionProveedorSubasta> InvitacionProveedorSubasta { get; set; }
        public DbSet<ProveedorSubasta> ProveedorSubasta { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Mensaje> Mensaje { get; set; }
        public DbSet<ItemsRonda> ItemsRonda { get; set; }
        public DbSet<RespuestaRonda> RespuestaRonda { get; set; }
        public DbSet<Ronda> Ronda { get; set; }
        public DbSet<UsuarioRonda> UsuarioRonda { get; set; }
        public DbSet<UsuarioReasignacionSubasta> UsuarioReasignacionSubasta { get; set; }
        public DbSet<UsuarioEncargadoSubasta> UsuarioEncargadoSubasta { get; set; }
        public DbSet<UsuarioColaboradorSubasta> UsuarioColaboradorSubasta { get; set; }
        public DbSet<TrazabilidadSubasta> TrazabilidadSubasta { get; set; }
        public DbSet<OfertaSubasta> OfertaSubasta { get; set; }
        public DbSet<RondaHolandesaItem> RondaHolandesaItem { get; set; }
        public DbSet<ConfiguracionSubastaInglesa> ConfiguracionSubastaInglesa { get; set; }

        public DbSet<ZonaHoraria> ZonaHoraria {  get; set; }

        public DbSet<Usuario> Usuario { get; set; }

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
            new ItemSubastaConfiguration(modelBuilder.Entity<ItemSubasta>());
            new GanadorSubastaConfiguration(modelBuilder.Entity<GanadorSubasta>());
            new RegionSubastaConfiguration(modelBuilder.Entity<PaisSubasta>());
            new SubastaConfiguration(modelBuilder.Entity<Subasta>());
            new SubastaTemporalConfiguration(modelBuilder.Entity<SubastaTemporal>());
            new TipoSubastaConfiguration(modelBuilder.Entity<TipoSubasta>());
            new CorreoConfiguration(modelBuilder.Entity<Correo>());
            new InvitacionProveedorSubastaConfiguration(modelBuilder.Entity<InvitacionProveedorSubasta>());
            new ProveedorSubastaConfiguration(modelBuilder.Entity<ProveedorSubasta>());
            new EstadoConfiguration(modelBuilder.Entity<Estado>());
            new MensajeConfiguration(modelBuilder.Entity<Mensaje>());
            new ItemsRondaConfiguration(modelBuilder.Entity<ItemsRonda>());
            new RespuestaRondaConfiguration(modelBuilder.Entity<RespuestaRonda>());
            new RondaConfiguration(modelBuilder.Entity<Ronda>());
            new UsuarioRondaConfiguration(modelBuilder.Entity<UsuarioRonda>());
            new UsuarioReasignacionSubastaConfiguration(modelBuilder.Entity<UsuarioReasignacionSubasta>());
            new UsuarioEncargadoSubastaConfiguration(modelBuilder.Entity<UsuarioEncargadoSubasta>());
            new UsuarioColaboradorSubastaConfiguration(modelBuilder.Entity<UsuarioColaboradorSubasta>());
            new TrazabilidadSubastaConfiguration(modelBuilder.Entity<TrazabilidadSubasta>());
            new OfertaSubastaConfiguration(modelBuilder.Entity<OfertaSubasta>());
            new RondaHolandesaItemConfiguration(modelBuilder.Entity<RondaHolandesaItem>());
            new ConfiguracionSubastaInglesaConfiguration(modelBuilder.Entity<ConfiguracionSubastaInglesa>());
            new ZonaHorariaConfiguration(modelBuilder.Entity<ZonaHoraria>());
            new UsuarioConfiguration(modelBuilder.Entity<Usuario>());
        }

    }
}
