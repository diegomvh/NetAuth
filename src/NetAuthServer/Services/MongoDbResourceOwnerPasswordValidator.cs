using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace NetAuthServer.Services
{
    public class MongoDbResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IRepository _repository;

        public MongoDbResourceOwnerPasswordValidator(IRepository repository)
        {
            _repository = repository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userName = context.UserName;
            var password = context.Password;
            var optionalClaims = new List<Claim>() {};

            if (_repository.ValidatePassword(userName, password))
            {
                return Task.FromResult(new GrantValidationResult(userName, "password", optionalClaims));
            }
       
            return Task.FromResult(new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong username or password"));
        }
    }
}
