using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Article)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(x => x.Article)
                .IsUnique();

            builder.Property(x => x.Barcode)
                .HasMaxLength(50)
                .IsRequired();
            builder.HasIndex(x => x.Barcode)
                .IsUnique();

            builder.Property(x => x.Price)
                .HasPrecision(18, 2);

            builder.Property(x => x.Weight)
                .HasPrecision(10, 3);

            builder.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired(false);

        }
    }
}
