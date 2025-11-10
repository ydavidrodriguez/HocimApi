using Holcim.Provider.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Holcim.Provider.Application
{
    public interface IDataBaseService
    {
        public DbSet<RespuestaPregunta> RespuestaPregunta { get; set; }

        public DbSet<ProveedorUsuario> ProveedorUsuario { get; set; }

        public DbSet<RespuestaPreguntaPorcentaje> RespuestaPreguntaPorcentaje { get; set; }

        Task<bool> SaveAsync();
    }
}
