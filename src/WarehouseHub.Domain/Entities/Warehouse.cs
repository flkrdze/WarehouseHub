using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Domain.Entities
{
    public class Warehouse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public Guid CompanyId { get; private set;  }
        public Company Company { get; private set; } = null!;

        private Warehouse()
        {
            Name = null!;
            Address = null!;
        }

        public Warehouse(string name,
            string address,
            Guid companyId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address hash cannot be empty.");

            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            CompanyId = companyId;
        }
    }
}
