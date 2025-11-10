using Holcim.Domain.Entities.Idioma;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class IdiomaConfiguration
    {
        public IdiomaConfiguration(EntityTypeBuilder<Idioma> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdIdioma);
        }
    }
}
