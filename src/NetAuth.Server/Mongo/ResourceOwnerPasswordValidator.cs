using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using MongoDB.Driver;

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
            
            var user = Repository.Users.Find(u => u.Username == username).FirstOrDefault();

            context.Result = user?.Password == password ?
                new GrantValidationResult(user.Sid, "pwd"):
                new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Wrong username or password");

            return Task.FromResult(0);
        }
    }
}
