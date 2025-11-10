using Holcim.Domain.Entities.Proveedor;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class ProveedorConfiguration
    {
        public ProveedorConfiguration(EntityTypeBuilder<Proveedor> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdProveedor);
        }

    }
}
