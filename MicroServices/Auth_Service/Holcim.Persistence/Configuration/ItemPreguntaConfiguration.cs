using Holcim.Domain.Entities.Item;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    internal class ItemPreguntaConfiguration
    {
        public ItemPreguntaConfiguration(EntityTypeBuilder<ItemPregunta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdItemPregunta);
        }
    }
}
