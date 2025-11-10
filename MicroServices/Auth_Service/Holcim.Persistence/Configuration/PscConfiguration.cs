using Holcim.Domain.Entities.Pscs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class PscConfiguration
    {
        public PscConfiguration(EntityTypeBuilder<Pscs> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPscs);
        }

    }
}
