using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Contracts.Authentication
{
    public class RegisterRequest
    {
        public string CompanyName { get; init; } = string.Empty;
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
