using Holcim.AuctionService.Domain.Entities.ZonaHoraria;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.AuctionService.Persistence.Configuration
{
    public class ZonaHorariaConfiguration
    {
        public ZonaHorariaConfiguration(EntityTypeBuilder<ZonaHoraria> entityBuilder)
        {
            entityBuilder.HasKey(a => a.IdZonaHoraria);
        }
    }
}
