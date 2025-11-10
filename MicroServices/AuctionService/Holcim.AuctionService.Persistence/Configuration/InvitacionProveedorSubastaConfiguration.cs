using Holcim.AuctionService.Domain.Entities.ItemSubasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Holcim.AuctionService.Domain.Entities.Subasta;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class InvitacionProveedorSubastaConfiguration
    {
        public InvitacionProveedorSubastaConfiguration(EntityTypeBuilder<InvitacionProveedorSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdInvitacionProveedorSubasta);
        }

    }
}
