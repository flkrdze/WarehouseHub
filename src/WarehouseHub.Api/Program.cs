using WarehouseHub.Contracts.Authentication;
using Microsoft.EntityFrameworkCore;
using WarehouseHub.Infrastructure;
using WarehouseHub.Infrastructure.Extensions;
using WarehouseHub.Infrastructure.Persistence;
using WarehouseHub.Api.Endpoints.Authentication;
using WarehouseHub.Application.Authentication.Register;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<RegisterUserHandler>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WarehouseHubDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

//app.UseHttpsRedirection();
app.MapRegisterEndpoint();

app.Run();
