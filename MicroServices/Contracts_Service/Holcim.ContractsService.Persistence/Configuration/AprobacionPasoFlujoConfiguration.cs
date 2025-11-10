using Holcim.ContractsService.Domain.Entities.Aprobaciones;
using Holcim.ContractsService.Domain.Entities.Contratos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.ContractsService.Persistence.Configuration
{
    public class AprobacionPasoFlujoConfiguration
    {
        public AprobacionPasoFlujoConfiguration(EntityTypeBuilder<AprobacionPasoFlujo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdAprobacionPasoFlujo);
        }

    }
}
