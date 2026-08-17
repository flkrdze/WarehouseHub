using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Application.Abstractions.Persistence;
using WarehouseHub.Contracts.Warehouses;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Application.Warehouses.Create
{
    public sealed class CreateWarehouseHandler
    {
        private readonly IApplicationDbContext _db;

        public CreateWarehouseHandler(IApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<CreateWarehouseResult> Handle(
            Guid userId,
            CreateWarehouseRequest request,
            CancellationToken cancellationToken)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(
                    x => x.Id == userId,
                    cancellationToken);

            if (user is null)
            {
                return new CreateWarehouseResult
                {
                    Success = false,
                    Error = "User not found."
                };
            }

            var warehouse = new Warehouse(
                request.Name,
                request.Address,
                user.CompanyId);

            _db.Warehouses.Add(warehouse);

            await _db.SaveChangesAsync(cancellationToken);

            return new CreateWarehouseResult
            {
                Success = true,
                WarehouseId = warehouse.Id
            };
        }
    }
}