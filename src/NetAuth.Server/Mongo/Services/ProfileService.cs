
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using MongoDB.Driver;

namespace NetAuth.Server.Mongo.Services
{
    public class ProfileService : IProfileService
    {
        public IMongoRepository Repository;
        public ProfileService(IMongoRepository repository) {
            Repository = repository;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.GetSubjectId();

            var user = Repository.Users.Find(u => u.Sid == subjectId).FirstOrDefault();

            context.IssuedClaims = user.Claims.Select(c => new Claim(c.Type, c.Value)).ToList();

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var subjectId = context.Subject.GetSubjectId();
            
            var user = Repository.Users.Find(u => u.Sid == subjectId).FirstOrDefault();
            context.IsActive = (user != null) && user.IsActive;
            
            return Task.FromResult(0);
        }
    }
}
