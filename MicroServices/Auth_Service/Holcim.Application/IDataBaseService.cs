using Holcim.Domain.Entities.Acciones;
using Holcim.Domain.Entities.AccionesMenu;
using Holcim.Domain.Entities.Archivos;
using Holcim.Domain.Entities.Cargo;
using Holcim.Domain.Entities.Correo;
using Holcim.Domain.Entities.CuentaAdmin;
using Holcim.Domain.Entities.Dependencia;
using Holcim.Domain.Entities.Estado;
using Holcim.Domain.Entities.Idioma;
using Holcim.Domain.Entities.Informes;
using Holcim.Domain.Entities.Item;
using Holcim.Domain.Entities.Menu;
using Holcim.Domain.Entities.Moneda;
using Holcim.Domain.Entities.Motivos;
using Holcim.Domain.Entities.Notificaciones;
using Holcim.Domain.Entities.Pais;
using Holcim.Domain.Entities.PreguntaArchivo;
using Holcim.Domain.Entities.Proveedor;
using Holcim.Domain.Entities.ProveedorRfx;
using Holcim.Domain.Entities.Pscs;
using Holcim.Domain.Entities.Region;
using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Entities.Rol;
using Holcim.Domain.Entities.RolMenu;
using Holcim.Domain.Entities.TipoArchivo;
using Holcim.Domain.Entities.TipoEstado;
using Holcim.Domain.Entities.TipoPais;
using Holcim.Domain.Entities.TipoRfx;
using Holcim.Domain.Entities.TipoUsuario;
using Holcim.Domain.Entities.UnidadMedida;
using Holcim.Domain.Entities.Usuario;
using Holcim.Domain.Entities.UsuarioNotificaciones;
using Holcim.Domain.Entities.ZonaHoraria;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Application
{
    public interface IDataBaseService
    {
        public DbSet<Acciones> Acciones { get; set; }
        public DbSet<AccionesMenu> AccionesMenu { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<CuentaAdmin> CuentaAdmin { get; set; }
        public DbSet<Departamento> Dependencia { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Notificaciones> Notificaciones { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        public DbSet<UsuarioNotificaciones> UsuarioNotificaciones { get; set; }
        public DbSet<Idioma> Idioma { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<UsuarioToken> UsuarioToken { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Pscs> Pscs { get; set; }
        public DbSet<CategoriaPsc> CategoriaPsc { get; set; }
        public DbSet<GrupoPsc> GrupoPsc { get; set; }
        public DbSet<ZonaHoraria> ZonaHoraria { get; set; }
        public DbSet<ZonaHorariaPais> ZonaHorariaPais { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<Informes> Informes { get; set; }
        public DbSet<InformesRol> InformesRol { get; set; }
        public DbSet<TipoRfx> TipoRfx { get; set; }
        public DbSet<Rfx> Rfx { get; set; }
        public DbSet<RfxItem> RfxItem { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<ItemDetalle> ItemDetalle { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<TipoEstado> TipoEstado { get; set; }

        public DbSet<ArchivoSobre> ArchivoSobre { get; set; }
        public DbSet<ValoresArchivo> ValoresArchivo { get; set; }
        public DbSet<PreguntaArchivo> PreguntaArchivo { get; set; }
        public DbSet<TipoArchivo> TipoArchivo { get; set; }
        public DbSet<TipoArchivoRfx> TipoArchivoRfx { get; set; }
        public DbSet<ItemPregunta> ItemPregunta { get; set; }
        public DbSet<Correo> Correo { get; set; }
        public DbSet<PreguntaSobreRfx> PreguntaSobreRfx { get; set; }
        public DbSet<TrazabilidadRfx> TrazabilidadRfx { get; set; }
        public DbSet<UsuarioEncargadoRfx> UsuarioEncargadoRfx { get; set; }
        public DbSet<InvitacionProveedorRfx> InvitacionProveedorRfx { get; set; }
        public DbSet<UsuarioReasignacion> UsuarioReasignacion { get; set; }
        public DbSet<Motivo> Motivo { get; set; }
        public DbSet<ProveedorRfx> ProveedorRfx { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<TipoPais> TipoPais { get; set; }
        public DbSet<RfxPais> RfxPais{ get; set; }
        public DbSet<RfxTemporal> RfxTemporal { get; set; }
        public DbSet<AdjudicacionProveedor> AdjudicacionProveedor { get; set; }
        Task<bool> SaveAsync();
    }
}
