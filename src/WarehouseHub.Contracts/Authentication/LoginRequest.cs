using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Contracts.Authentication
{
    public class LoginRequest
    {
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
