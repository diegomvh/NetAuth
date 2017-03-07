using NetAuthServer.Models;

namespace NetAuthServer.Services
{
    public interface IRepository
    {
        User GetUserByUsername(string username);
        User GetUserById(string id);
        bool ValidatePassword(string username, string plainTextPassword);
        Client GetClient(string clientId);

    }
}
