using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; private set; }
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; } = null!;
        public Guid ShelfId { get; private set; }
        public Shelf Shelf { get; private set; } = null!;

        private Stock()
        {
        }

        public Stock(int quantity,
            Guid productId,
            Guid shelfId)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            Id = Guid.NewGuid();
            Quantity = quantity;
            ProductId = productId;
            ShelfId = shelfId;
        }
    }
}
