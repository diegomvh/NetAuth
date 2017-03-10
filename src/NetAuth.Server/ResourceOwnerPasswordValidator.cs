using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace NetAuth.Server
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userName = context.UserName;
            var password = context.Password;
            
            /* 
            context.Result = _context.ValidatePassword(userName, password) ?
                new GrantValidationResult(userName, "password"):
                new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong username or password");
            */
            context.Result = userName == password ?
                new GrantValidationResult(userName, "password") :
                new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong username or password");
            
            return Task.FromResult(0);
        }
    }
}
