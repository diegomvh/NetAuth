using IdentityServer4.Validation;
using NetAuth.IdentityServer.Mongo;
using NetAuth.IdentityServer.Mongo.Repositories;

namespace NetAuth.IdentityServer.Quickstart.Login
{
    public class LoginService
    {
        private readonly IResourceOwnerPasswordValidator _passwordValidator;
        private readonly IContext _context;

        public LoginService(IResourceOwnerPasswordValidator passwordValidator, IContext context)
        {
            _passwordValidator = passwordValidator;
            _context = context;
        }

        public bool ValidateCredentials(string username, string password)
        {
            return _context.ValidatePassword(username, password);
        }

        public NetAuth.IdentityServer.Mongo.Models.User FindByUsername(string username)
        {
            var collection = _context.GetRepository<NetAuth.IdentityServer.Mongo.Models.User>() as UserRepository;
            return collection.GetUserByUsername(username);
        }
    }
}
