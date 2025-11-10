using Holcim.Domain.Entities.Item;
using Holcim.Domain.Entities.Rfx;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class InvitacionProveedorRfxConfiguration
    {
        public InvitacionProveedorRfxConfiguration(EntityTypeBuilder<InvitacionProveedorRfx> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdInvitacionProveedorRfx);
        }

    }
}
