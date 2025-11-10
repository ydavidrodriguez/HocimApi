using Holcim.Domain.Entities.Correo;
using Holcim.Domain.Entities.Pscs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class CorreoConfiguration
    {
        public CorreoConfiguration(EntityTypeBuilder<Correo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdCorreo);
        }
    }
}
