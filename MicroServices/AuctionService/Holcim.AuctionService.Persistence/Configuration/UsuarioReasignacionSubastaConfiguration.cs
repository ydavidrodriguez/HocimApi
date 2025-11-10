using Holcim.AuctionService.Domain.Entities.Region;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class UsuarioReasignacionSubastaConfiguration
    {
        public UsuarioReasignacionSubastaConfiguration(EntityTypeBuilder<UsuarioReasignacionSubasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdUsuarioReasignacionSubasta);
        }
    }
}
