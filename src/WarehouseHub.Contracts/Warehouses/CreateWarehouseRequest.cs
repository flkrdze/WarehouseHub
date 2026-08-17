using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Contracts.Warehouses
{
    public sealed class CreateWarehouseRequest
    {
        public string Name { get; init; } = String.Empty;
        public string Address { get; init;  } = String.Empty;

    }
}
