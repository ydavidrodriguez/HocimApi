using Holcim.AuctionService.Domain.Entities.Region;
using Holcim.AuctionService.Domain.Entities.Subasta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class SubastaConfiguration
    {
        public SubastaConfiguration(EntityTypeBuilder<Subasta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdSubasta);
            entityBuilder.Property(x => x.CodigoSubasta)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            entityBuilder.Property(x => x.FechaCreacion)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                
        }
    }
}
