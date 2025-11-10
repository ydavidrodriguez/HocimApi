using Holcim.Domain.Entities.Menu;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class MenuConfiguration
    {
        public MenuConfiguration(EntityTypeBuilder<Menu> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdMenu);
        }

    }
}
