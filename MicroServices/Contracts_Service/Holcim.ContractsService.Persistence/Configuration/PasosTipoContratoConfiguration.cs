using Holcim.ContractsService.Domain.Entities.Pasos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.ContractsService.Persistence.Configuration
{
    public class PasosTipoContratoConfiguration
    {
        public PasosTipoContratoConfiguration(EntityTypeBuilder<PasosTipoContrato> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPasosTipoContrato);
        }
    }
}
