using Holcim.AuctionService.Domain.Entities.Estado;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class EstadoConfiguration
    {
        public EstadoConfiguration(EntityTypeBuilder<Estado> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdEstado);
        }
    }
}
