using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class UsuarioColaboradorSubastaConfiguration
    {
        public UsuarioColaboradorSubastaConfiguration(EntityTypeBuilder<UsuarioColaboradorSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuarioColaboradorSubasta);
        }
    }
}
