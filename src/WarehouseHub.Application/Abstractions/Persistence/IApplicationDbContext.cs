using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Application.Abstractions.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<User> Users { get; }
        public DbSet<Company> Companies { get; }
        public DbSet<Warehouse> Warehouses { get; }
        public DbSet<Shelf> Shelves { get; }
        public DbSet<Stock> Stocks { get; }

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
