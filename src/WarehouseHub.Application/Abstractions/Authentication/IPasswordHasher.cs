namespace WarehouseHub.Application.Abstractions.Authentication
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
