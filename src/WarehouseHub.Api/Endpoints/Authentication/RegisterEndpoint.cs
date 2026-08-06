using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WarehouseHub.Contracts.Authentication;
using WarehouseHub.Infrastructure.Persistence;
using WarehouseHub.Application.Authentication.Register;

namespace WarehouseHub.Api.Endpoints.Authentication
{
    public static class RegisterEndpoint
    {
        public static IEndpointRouteBuilder MapRegisterEndpoint(this IEndpointRouteBuilder app)
        {
            var auth = app.MapGroup("/api/auth");

            auth.MapPost("/register", async (
                RegisterRequest request,
                RegisterUserHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.Handle(request, ct);

                if (!result.Success)
                {
                    return Results.Conflict(new
                    {
                        message = result.Error
                    });
                }

                return Results.Created();
            }).WithName("Register");

            return app;
        }
    }
}
