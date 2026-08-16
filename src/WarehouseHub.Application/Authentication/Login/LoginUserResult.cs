using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Application.Authentication.Login
{
    public sealed class LoginUserResult
    {
        public bool Success { get; init; }
        public LoginUserError Error { get; init; }
        public string? Token { get; init; }
    }
}
