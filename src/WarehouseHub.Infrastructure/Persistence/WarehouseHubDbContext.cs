using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Infrastructure.Persistence
{
    class WarehouseHubDbContext : DbContext
    {
        public WarehouseHubDbContext(DbContextOptions<WarehouseHubDbContext> options)
            : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Shelf> Shelf => Set<Shelf>();
        public DbSet<Stock> Stocks => Set<Stock>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WarehouseHubDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
