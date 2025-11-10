using Holcim.AuctionService.Domain.Entities.Ronda;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class RespuestaRondaConfiguration
    {
        public RespuestaRondaConfiguration(EntityTypeBuilder<RespuestaRonda> entityBuilder)
        {
            entityBuilder.HasKey(x => x.RespuestaRondaId);
        }
    }
}
