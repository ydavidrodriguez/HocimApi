using Holcim.AuctionService.Domain.Entities.ItemSubasta;
using Holcim.AuctionService.Domain.Entities.Mensaje;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class MensajeConfiguration
    {
        public MensajeConfiguration(EntityTypeBuilder<Mensaje> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdMensaje);
        }

    }
}
