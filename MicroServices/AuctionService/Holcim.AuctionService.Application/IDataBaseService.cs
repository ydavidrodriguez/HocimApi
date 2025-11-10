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
using Microsoft.EntityFrameworkCore;

namespace Holcim.AuctionService.Application
{
    public interface IDataBaseService
    {
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
        Task<bool> SaveAsync();

    }
}
