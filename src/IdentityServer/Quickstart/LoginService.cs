using IdentityServer4.Validation;

namespace NetAuth.IdentityServer.Quickstart.Login
{
    public class LoginService
    {
        private readonly IResourceOwnerPasswordValidator _passwordValidator;
        
        public LoginService(IResourceOwnerPasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

    }
}
