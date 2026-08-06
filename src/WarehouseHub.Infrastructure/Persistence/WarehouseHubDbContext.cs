using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Application.Abstractions.Persistence;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Infrastructure.Persistence
{
    public class WarehouseHubDbContext
        : DbContext, IApplicationDbContext
    {
        public WarehouseHubDbContext(DbContextOptions<WarehouseHubDbContext> options)
            : base(options) 
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<Shelf> Shelves => Set<Shelf>();
        public DbSet<Stock> Stocks => Set<Stock>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WarehouseHubDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
