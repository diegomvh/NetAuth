using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace NetAuth.Server.Mongo
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public IMongoRepository Repository;
        public ResourceOwnerPasswordValidator(IMongoRepository repository) {
            Repository = repository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var username = context.UserName;
            var password = context.Password;
            
            context.Result = Repository.ValidateCredentials(username, password) ?
                new GrantValidationResult(username, "password"):
                new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong username or password");
            
            return Task.FromResult(0);
        }
    }
}
