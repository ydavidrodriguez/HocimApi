using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class AdjudicacionProveedorConfiguration
    {
        public AdjudicacionProveedorConfiguration(EntityTypeBuilder<Domain.Entities.Proveedor.AdjudicacionProveedor> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdAdjudicacionProveedor);
        }

    }
}
