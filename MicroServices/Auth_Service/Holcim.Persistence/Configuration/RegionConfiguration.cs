using Holcim.Domain.Entities.Region;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class RegionConfiguration
    {
        public RegionConfiguration(EntityTypeBuilder<Region> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRegion);
            
        }
    }
}
