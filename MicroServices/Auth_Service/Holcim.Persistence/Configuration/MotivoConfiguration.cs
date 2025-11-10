using Holcim.Domain.Entities.Motivos;
using Holcim.Domain.Entities.Notificaciones;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class MotivoConfiguration
    {
        public MotivoConfiguration(EntityTypeBuilder<Motivo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdMotivo);
        }

    }
}
