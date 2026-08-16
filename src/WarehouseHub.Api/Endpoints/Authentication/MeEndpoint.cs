using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WarehouseHub.Api.Endpoints.Authentication
{
    public static class MeEndpoint
    {
        public static IEndpointRouteBuilder MapMeEndpoint(
            this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/auth/me", [Authorize] (ClaimsPrincipal user) =>
            {
                var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

                return Results.Ok(new
                {
                    userId
                });
            });

            return app;
        }
    }
}
