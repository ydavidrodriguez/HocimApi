using Holcim.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.Persistence.Configuration
{
    public class UsuarioOtpConfiguration
    {
        public UsuarioOtpConfiguration(EntityTypeBuilder<UsuarioOtp> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuarioOtp);
        }
    }
}
