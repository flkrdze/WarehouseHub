using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WarehouseHub.Contracts.Authentication;
using WarehouseHub.Application.Abstractions.Persistence;
using WarehouseHub.Domain.Entities;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using WarehouseHub.Domain.Enums;
using WarehouseHub.Application.Abstractions.Authentication;
using System.ComponentModel.DataAnnotations;

namespace WarehouseHub.Application.Authentication.Register
{
    public class RegisterUserHandler
    {
        private readonly IApplicationDbContext _db;
        private readonly IPasswordHasher _hasher;

        public RegisterUserHandler(IApplicationDbContext db, IPasswordHasher hasher)
        {
            _db = db;
            _hasher = hasher;
        }

        public async Task<RegisterUserResult> Handle(
        RegisterRequest request,
        CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(request.CompanyName))
            {
                return new RegisterUserResult
                {
                    Success = false,
                    Error = RegisterUserError.InvalidCompanyName
                };
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                return new RegisterUserResult
                {
                    Success = false,
                    Error = RegisterUserError.InvalidFirstName
                };
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                return new RegisterUserResult
                {
                    Success = false,
                    Error = RegisterUserError.InvalidLastName
                };
            }

            bool isPasswordValid = request.Password.Length >= 8;

            if (!isPasswordValid)
            {
                return new RegisterUserResult
                {
                    Success = false,
                    Error = RegisterUserError.InvalidPassword
                };
            }

            var email = request.Email.Trim().ToLowerInvariant();

            if (!new EmailAddressAttribute().IsValid(email))
            {
                return new RegisterUserResult
                {
                    Success = false,
                    Error = RegisterUserError.InvalidEmail
                };
            }

            var exists = await _db.Users.
                AnyAsync(x => x.Email == email, cancellationToken);

            if (exists)
            {
                return new RegisterUserResult
                {
                    Success = false,
                    Error = RegisterUserError.EmailAlreadyExists
                };
            }

            var company = new Company(request.CompanyName);

            var passwordHash = _hasher.HashPassword(request.Password);

            var user = new User(
                email,
                passwordHash,
                request.FirstName,
                request.LastName,
                UserRole.Owner,
                company.Id);

            _db.Companies.Add(company);
            _db.Users.Add(user);

            await _db.SaveChangesAsync(cancellationToken);

            return new RegisterUserResult
            {
                Success = true
            };
        }
    }
}
