using Holcim.AuctionService.Domain.Entities.Ronda;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class UsuarioRondaConfiguration
    {
        public UsuarioRondaConfiguration(EntityTypeBuilder<UsuarioRonda> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdIUsuarioRonda);
        }
    }
}
