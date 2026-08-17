using System.Security.Claims;
using WarehouseHub.Application.Warehouses.Create;
using WarehouseHub.Contracts.Warehouses;
using System.IdentityModel.Tokens.Jwt;

namespace WarehouseHub.Api.Endpoints
{
    public static class CreateWarehouseEndpoint
    {
        public static IEndpointRouteBuilder MapCreateWarehouseEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/warehouses", async (
                CreateWarehouseRequest request,
                CreateWarehouseHandler handler,
                ClaimsPrincipal user,
                CancellationToken ct) =>
            {
                var userIdValue = user.FindFirstValue(
                    ClaimTypes.NameIdentifier);

                if (!Guid.TryParse(userIdValue, out var userId))
                {
                    return Results.Unauthorized();
                }

                var result = await handler.Handle(
                    userId,
                    request,
                    ct);

                if (!result.Success)
                {
                    return Results.BadRequest(new
                    {
                        message = result.Error
                    });
                }

                return Results.Created(
                    $"/api/warehouses/{result.WarehouseId}",
                    new
                    {
                        id = result.WarehouseId
                    });
            })
            .RequireAuthorization()
            .WithName("CreateWarehouse");

            return app;
        }
    }
}

