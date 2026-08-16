using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WarehouseHub.Contracts.Authentication;
using WarehouseHub.Infrastructure.Persistence;
using WarehouseHub.Application.Authentication.Register;
using WarehouseHub.Application.Authentication.Login;

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
                    return result.Error switch
                    {
                        RegisterUserError.EmailAlreadyExists =>
                            Results.Conflict(new { message = "Email is already registered." }),

                        RegisterUserError.InvalidPassword =>
                            Results.BadRequest(new { message = "Password is invalid." }),

                        RegisterUserError.InvalidEmail =>
                            Results.BadRequest(new { message = "Email is invalid." }),

                        _ =>
                            Results.BadRequest(new { message = "Invalid registration data." })
                    };
                }

                return Results.Created();
            }).WithName("Register");

            auth.MapPost("/login", async (
                LoginRequest request,
                LoginUserHandler handler,
                CancellationToken ct) => 
            {
                var result = await handler.Handle(request, ct);

                if (!result.Success)
                {
                    return result.Error switch
                    {
                        LoginUserError.InvalidPassword =>
                            Results.BadRequest(new { message = "Password is invalid." }),

                        LoginUserError.InvalidEmail =>
                            Results.BadRequest(new { message = "Email is invalid." }),

                        LoginUserError.WrongPassword =>
                            Results.BadRequest(new { message = "Password is wrong" }),

                        _ =>
                            Results.BadRequest(new {message = "Invalid login data"})
                    };
                }
                return Results.Ok();

            }).WithName("Login");

            return app;
        }
    }
}
