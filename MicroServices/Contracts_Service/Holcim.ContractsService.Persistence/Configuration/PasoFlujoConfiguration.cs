using Holcim.ContractsService.Domain.Entities.Pasos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.ContractsService.Persistence.Configuration
{
    public class PasoFlujoConfiguration
    {
        public PasoFlujoConfiguration(EntityTypeBuilder<PasoFlujo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPasoFlujo);
        }

    }
}
