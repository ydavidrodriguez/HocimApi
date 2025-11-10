using Holcim.Provider.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Provider.Persistence.Configuration
{
    public class RespuestaPreguntaConfiguration
    {
        public RespuestaPreguntaConfiguration(EntityTypeBuilder<RespuestaPregunta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRespuestaPregunta);
        }

    }
}
