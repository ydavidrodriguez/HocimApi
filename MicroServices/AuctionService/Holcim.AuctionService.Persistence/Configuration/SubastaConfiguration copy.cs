using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class ConfiguracionSubastaInglesaConfiguration
    {
        public ConfiguracionSubastaInglesaConfiguration(EntityTypeBuilder<ConfiguracionSubastaInglesa> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdConfiguracionSubasta);
                
        }
    }
}
