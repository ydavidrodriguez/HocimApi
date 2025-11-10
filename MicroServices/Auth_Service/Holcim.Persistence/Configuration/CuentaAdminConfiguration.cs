using Holcim.Domain.Entities.CuentaAdmin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class CuentaAdminConfiguration
    {
        public CuentaAdminConfiguration(EntityTypeBuilder<CuentaAdmin> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdCuentaAdmin);
        }

    }
}
