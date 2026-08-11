using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Identity;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Infrastructure.Authentication
{
    internal class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<User> _hasher = new();
        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null, password);
        }
    }
}
