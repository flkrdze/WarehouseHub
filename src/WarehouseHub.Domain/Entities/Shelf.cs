using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Domain.Entities
{
    public class Shelf
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public decimal CapacityInKg {  get; private set; }
        public Guid WarehouseId { get; private set;  }
        public Warehouse Warehouse { get; private set; } = null!;
        public ICollection<Stock> Stocks { get; private set; } = new List<Stock>();

        private Shelf( )
        {
            Code = null!;
        }

        public Shelf(string code,
            decimal capacityInKg,
            Guid warehouseId)
        {
            if (capacityInKg < 0)
                throw new ArgumentOutOfRangeException("Capacity is negative value");

            Id = Guid.NewGuid();
            Code = code;
            CapacityInKg = capacityInKg;
            WarehouseId = warehouseId;
        }
    }
}
