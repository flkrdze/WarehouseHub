using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Article { get; private set;  }
        public string Barcode { get; private set; }
        public decimal Price { get; private set; }
        public decimal Weight { get; private set; }
        public string? Description { get; private set; }
        public bool IsArchived { get; private set; }

        private Product ( ) 
        {
            Name = null!;
            Article = null!;
            Barcode = null!;
        }
        public Product (string name,
            string article,
            string barcode,
            decimal price,
            decimal weight)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (string.IsNullOrWhiteSpace(article))
                throw new ArgumentException("Article cannot be empty", nameof(article));
            if (string.IsNullOrWhiteSpace(barcode))
                throw new ArgumentException("Barcode cannot be empty", nameof(barcode));

            if (price <= 0 || weight <= 0)
            {
                throw new ArgumentException("Product price and weight can't has negative or 0 value");
            }
            
            Id = Guid.NewGuid();
            Name = name;
            Article = article;
            Barcode = barcode;
            Price = price;
            Weight = weight;
        }
    }
}
