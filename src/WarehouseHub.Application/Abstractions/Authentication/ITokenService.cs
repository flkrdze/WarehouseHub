using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Application.Abstractions.Authentication
{
    public interface ITokenService
    {
        string GenerateToken(Guid userId);
    }
}
