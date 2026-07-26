using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Domain.Enums;

namespace WarehouseHub.Domain.Entities
{
    public class User
    {
        public Guid Id {  get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set;  }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public UserRole Role { get; private set; }
        public Guid CompanyId { get; private set; }
        public Company Company { get; private set; } = null!;

        private User()
        {
            Email = null!;
            PasswordHash = null!;
            FirstName = null!;
            LastName = null!;
        }

        public User(string email,
            string passwordHash,
            string firstName,
            string lastName,
            UserRole role,
            Guid companyId)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash cannot be empty.");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.");

            Id = Guid.NewGuid();
            Email = email.Trim();
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            CompanyId = companyId;
        }
    }
}
