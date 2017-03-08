using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace NetAuth.IdentityServer.Mongo
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IContext _context;

        public ResourceOwnerPasswordValidator(IContext context)
        {
            _context = context;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userName = context.UserName;
            var password = context.Password;
            
            context.Result = _context.ValidatePassword(userName, password) ?
                new GrantValidationResult(userName, "password"):
                new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong username or password");
            
            return Task.FromResult(0);
        }
    }
}
