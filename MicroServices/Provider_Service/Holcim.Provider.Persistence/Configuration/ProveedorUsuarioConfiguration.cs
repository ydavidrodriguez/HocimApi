using Holcim.Provider.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Provider.Persistence.Configuration
{
    public class ProveedorUsuarioConfiguration
    {
        public ProveedorUsuarioConfiguration(EntityTypeBuilder<ProveedorUsuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdProveedorUsuario);
        }

    }
}
