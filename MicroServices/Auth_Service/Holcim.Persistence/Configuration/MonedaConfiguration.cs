using Holcim.Domain.Entities.Moneda;
using Holcim.Domain.Models.Moneda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text.Json;

namespace Holcim.Persistence.Configuration
{
    public class MonedaConfiguration
    {
        public MonedaConfiguration(EntityTypeBuilder<Moneda> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdMoneda);

            entityBuilder.Property(x => x.ColumnasExtras)
                .HasColumnName("ColumnasExtrasJson")
                .HasConversion(
                    v => v == null || v.Count == 0 ? null : JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                    v => string.IsNullOrWhiteSpace(v)
                        ? new List<ColumnaExtraDto>()
                        : JsonSerializer.Deserialize<List<ColumnaExtraDto>>(v, new JsonSerializerOptions()) ?? new List<ColumnaExtraDto>());
        }
    }
}
