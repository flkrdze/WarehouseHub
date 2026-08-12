using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Application.Authentication.Register
{
    public sealed class RegisterUserResult
    {
        public bool Success { get; init; }
        public RegisterUserError Error { get; init; }
    }
}
