using Holcim.Domain.Entities.Moneda;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class MonedaConfiguration
    {
        public MonedaConfiguration(EntityTypeBuilder<Moneda> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdMoneda);
        }
    }
}
