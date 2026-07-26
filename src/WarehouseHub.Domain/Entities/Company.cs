using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Company()
        {
            Name = null!;
        }

        public Company(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Company name cannot be empty");
            Id = Guid.NewGuid();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

    }
}
