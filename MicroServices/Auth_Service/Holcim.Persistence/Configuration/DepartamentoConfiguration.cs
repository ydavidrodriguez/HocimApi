using Holcim.Domain.Entities.Dependencia;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class DepartamentoConfiguration
    {
        public DepartamentoConfiguration(EntityTypeBuilder<Departamento> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdDepartamento);
        }
    }
}
