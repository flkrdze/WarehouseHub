using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Application.Abstractions.Persistence;
using WarehouseHub.Contracts.Authentication;

namespace WarehouseHub.Application.Authentication.Login
{
    public class LoginUserHandler
    {
        private readonly IApplicationDbContext _db;

        public LoginUserHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<LoginUserResult> Handle(
            LoginRequest request,
            CancellationToken ct)
        {


            return new LoginUserResult
            {
                Succes = true;
            };
        }
    }
}
