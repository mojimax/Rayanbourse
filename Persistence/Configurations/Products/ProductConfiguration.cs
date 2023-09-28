using Domain.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.ProduceDate, x.ManufactureEmail }).IsUnique();
            builder.Property(x => x.ProduceDate).HasColumnType("date");
            builder.Property(x => x.ManufacturePhone).HasColumnType("varchar").HasMaxLength(12);
            builder.Property(x => x.ManufactureEmail).HasColumnType("varchar").HasMaxLength(100);
            builder.HasQueryFilter(x => !x.Deleted && x.IsAvailable);
        }
    }
}
