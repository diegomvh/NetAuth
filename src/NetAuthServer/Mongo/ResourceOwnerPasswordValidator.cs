using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace NetAuthServer.Mongo
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
            System.Console.Write("ValidateAsync");
            var userName = context.UserName;
            var password = context.Password;
            var optionalClaims = new List<Claim>() {};

            if (_context.ValidatePassword(userName, password))
            {
                return Task.FromResult(new GrantValidationResult(userName, "password", optionalClaims));
            }
       
            return Task.FromResult(new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong username or password"));
        }
    }
}
