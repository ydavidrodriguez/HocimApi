using Holcim.ContractsService.Domain.Entities.FlujoAprobacion;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.ContractsService.Persistence.Configuration
{
    public class FlujoAprobacionConfiguration
    {
        public FlujoAprobacionConfiguration(EntityTypeBuilder<FlujoAprobacion> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdFlujoAprobacion);
        }

    }
}
