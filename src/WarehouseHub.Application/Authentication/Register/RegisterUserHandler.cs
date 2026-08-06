using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WarehouseHub.Contracts.Authentication;
using WarehouseHub.Application.Abstractions.Persistence;

namespace WarehouseHub.Application.Authentication.Register
{
    public class RegisterUserHandler
    {
        private readonly IApplicationDbContext _db;

        public RegisterUserHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<RegisterUserResult> Handle(
        RegisterRequest request,
        CancellationToken cancellationToken)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var exists = await _db.Users.
                AnyAsync(x => x.Email == email, cancellationToken);

            if (exists)
            {
                return new RegisterUserResult
                {
                    Success = false,
                    Error = "Email is already registered."
                };
            }
            return new RegisterUserResult
            {
                Success = true
            };
        }
    }
}
