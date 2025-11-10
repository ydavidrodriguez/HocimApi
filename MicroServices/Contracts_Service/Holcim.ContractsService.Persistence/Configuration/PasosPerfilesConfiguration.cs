using Holcim.ContractsService.Domain.Entities.Pasos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.ContractsService.Persistence.Configuration
{
    public class PasosPerfilesConfiguration
    {
        public PasosPerfilesConfiguration(EntityTypeBuilder<PasosPerfiles> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPasosPerfiles);
        }
    }
}
