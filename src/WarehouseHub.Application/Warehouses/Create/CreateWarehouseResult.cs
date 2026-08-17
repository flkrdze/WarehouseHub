using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Application.Warehouses.Create;

public sealed class CreateWarehouseResult
{
    public bool Success { get; init; }
    public string? Error { get; init; }
    public Guid? WarehouseId { get; init; }
}
