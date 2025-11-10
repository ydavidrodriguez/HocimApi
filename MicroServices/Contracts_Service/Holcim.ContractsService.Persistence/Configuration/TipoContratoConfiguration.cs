using Holcim.ContractsService.Domain.Entities.Contratos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.ContractsService.Persistence.Configuration
{
    public class TipoContratoConfiguration
    {
        public TipoContratoConfiguration(EntityTypeBuilder<TipoContrato> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdTipoContrato);
        }
    }
}
