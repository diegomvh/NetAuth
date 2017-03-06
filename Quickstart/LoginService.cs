using IdentityServer4.Validation;
using NetAuth.Models;
using NetAuth.Services;

namespace NetAuth.Quickstart.Login
{
    public class LoginService
    {
        private readonly IResourceOwnerPasswordValidator _passwordValidator;
        private readonly IRepository _repository;

        public LoginService(IResourceOwnerPasswordValidator passwordValidator, IRepository repository)
        {
            _passwordValidator = passwordValidator;
            _repository = repository;
        }

        public bool ValidateCredentials(string username, string password)
        {
            return _repository.ValidatePassword(username, password);
        }

        public MongoDbUser FindByUsername(string username)
        {
            return _repository.GetUserByUsername(username);
        }
    }
}
