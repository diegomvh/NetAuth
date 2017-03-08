
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using NetAuth.IdentityServer.Mongo.Repositories;

namespace NetAuth.IdentityServer.Mongo.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IContext _context;
        private readonly UserRepository _repository;

        public ProfileService(IContext context)
        {
            _context = context;
            _repository = _context.GetRepository<NetAuth.IdentityServer.Mongo.Models.User>() as UserRepository;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            System.Console.Write("GetProfileDataAsync");
            var subjectId = context.Subject.GetSubjectId();

            //var user = _repository.GetUserById(subjectId);
            var user = InMemory.Users.Get().First(u => u.SubjectId == subjectId);
            /* 
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.SubjectId),
                new Claim(JwtClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtClaimTypes.GivenName, user.FirstName),
                new Claim(JwtClaimTypes.FamilyName, user.LastName),
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.EmailVerified, user.EmailVerified.ToString().ToLower(), ClaimValueTypes.Boolean)
            };
            context.IssuedClaims = claims;
            */

            context.IssuedClaims = new List<Claim>(user.Claims);

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            System.Console.Write("IsActiveAsync");
            var subjectId = context.Subject.GetSubjectId();
            
            //var user = _repository.GetUserById(context.Subject.GetSubjectId());
            //context.IsActive = (user != null) && user.IsActive;
            
            var user = InMemory.Users.Get().First(u => u.SubjectId == subjectId);
            context.IsActive = (user != null);
            
            return Task.FromResult(0);
        }
    }
}
