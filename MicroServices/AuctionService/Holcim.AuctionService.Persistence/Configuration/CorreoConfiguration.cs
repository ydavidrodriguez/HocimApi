using Holcim.AuctionService.Domain.Entities.Correo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class CorreoConfiguration
    {
        public CorreoConfiguration(EntityTypeBuilder<Correo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdCorreo);
        }
    }
}
