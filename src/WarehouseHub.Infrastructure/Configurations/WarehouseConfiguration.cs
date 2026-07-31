using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Infrastructure.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Warehouses)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}
