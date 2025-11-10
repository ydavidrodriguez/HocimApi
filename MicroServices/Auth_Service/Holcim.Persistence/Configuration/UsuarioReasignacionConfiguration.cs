using Holcim.Domain.Entities.Rfx;
using Holcim.Domain.Entities.UsuarioNotificaciones;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class UsuarioReasignacionConfiguration
    {
        public UsuarioReasignacionConfiguration(EntityTypeBuilder<UsuarioReasignacion> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuarioReasignacion);
        }
    }
}
