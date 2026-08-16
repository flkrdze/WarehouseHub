using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Application.Abstractions.Authentication;
using WarehouseHub.Application.Abstractions.Persistence;
using WarehouseHub.Contracts.Authentication;
using WarehouseHub.Domain.Entities;

namespace WarehouseHub.Application.Authentication.Login
{
    public class LoginUserHandler
    {
        private readonly IApplicationDbContext _db;
        private readonly IPasswordHasher _passwordHasher;

        public LoginUserHandler(IApplicationDbContext db, IPasswordHasher passwordHasher)
        {
            _db = db;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginUserResult> Handle(
            LoginRequest request,
            CancellationToken cancellationToken)
        {
            
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return new LoginUserResult
                {
                    Success = false,
                    Error = LoginUserError.InvalidEmail
                };
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return new LoginUserResult
                {
                    Success = false,
                    Error = LoginUserError.InvalidPassword
                };
            }

            var email = request.Email.Trim().ToLowerInvariant();
            var user = await _db.Users
                .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (user is null)
            {
                return new LoginUserResult
                {
                    Success = false,
                    Error = LoginUserError.InvalidEmail
                };
            }

            var isPasswordCorrect = _passwordHasher.VerifyPassword(
             request.Password,
             user.PasswordHash);

            if (!isPasswordCorrect)
            {
                return new LoginUserResult
                {
                    Success = false,
                    Error = LoginUserError.WrongPassword
                };
            }

            return new LoginUserResult
            {
                Success = true
            };
        }
    }
}
