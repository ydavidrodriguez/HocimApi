using Holcim.ContractsService.Domain.Entities.Contratos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.ContractsService.Persistence.Configuration
{
    public class ContratoConfiguration
    {
        public ContratoConfiguration(EntityTypeBuilder<Contrato> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdContrato);
        }
    }
}
