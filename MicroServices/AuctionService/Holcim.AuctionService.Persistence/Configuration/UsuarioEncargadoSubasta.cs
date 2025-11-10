using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class UsuarioEncargadoSubastaConfiguration
    {
        public UsuarioEncargadoSubastaConfiguration(EntityTypeBuilder<UsuarioEncargadoSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuarioEncargadoSubasta);
        }
    }
}
