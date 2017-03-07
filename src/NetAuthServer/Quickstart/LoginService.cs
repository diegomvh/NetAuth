using IdentityServer4.Validation;
using NetAuthServer.Models;
using NetAuthServer.Services;

namespace NetAuthServer.Quickstart.Login
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

        public User FindByUsername(string username)
        {
            return _repository.GetUserByUsername(username);
        }
    }
}
