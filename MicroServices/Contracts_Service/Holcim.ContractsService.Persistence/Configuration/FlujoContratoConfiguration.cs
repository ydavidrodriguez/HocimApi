using Holcim.ContractsService.Domain.Entities.FlujoAprobacion;
using Holcim.ContractsService.Domain.Entities.FlujoContrato;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.ContractsService.Persistence.Configuration
{
    public class FlujoContratoConfiguration
    {
        public FlujoContratoConfiguration(EntityTypeBuilder<FlujoContrato> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdFlujoContrato);
        }
    }
}
