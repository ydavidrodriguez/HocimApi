using Holcim.AuctionService.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class UsuarioConfiguration
    {
        public UsuarioConfiguration(EntityTypeBuilder<Usuario> entityBuilder) {
            entityBuilder.HasKey(a => a.IdUsuario);
        }
    }
}
