using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Application.Abstractions.Authentication;

namespace WarehouseHub.Infrastructure.Authentication
{
    public class JwtTokenService : ITokenService
    {
        public string GenerateToken(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
