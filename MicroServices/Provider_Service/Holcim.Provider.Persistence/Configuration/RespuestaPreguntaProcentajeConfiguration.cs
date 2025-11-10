using Holcim.Provider.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Provider.Persistence.Configuration
{
    public class RespuestaPreguntaProcentajeConfiguration
    {
        public RespuestaPreguntaProcentajeConfiguration(EntityTypeBuilder<RespuestaPreguntaPorcentaje> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdRespuestaPreguntaPorcentaje);
        }
    }
}
