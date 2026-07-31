using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Infrastructure.Configurations
{
    public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.CapacityInKg)
                .HasPrecision(18, 2);

            builder.HasOne(x => x.Warehouse)
                .WithMany(x => x.Shelves)
                .HasForeignKey(x => x.WarehouseId);
        }
    }
}
