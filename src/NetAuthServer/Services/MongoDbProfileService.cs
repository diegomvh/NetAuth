﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace NetAuthServer.Services
{
    public class MongoDbProfileService : IProfileService
    {
        private readonly IRepository _repository;

        public MongoDbProfileService(IRepository repository)
        {
            _repository = repository;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            System.Console.Write(context.Caller);
            var subjectId = context.Caller;

            var user = _repository.GetUserById(subjectId);

            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                new Claim(JwtClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtClaimTypes.GivenName, user.FirstName),
                new Claim(JwtClaimTypes.FamilyName, user.LastName),
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.EmailVerified, user.EmailVerified.ToString().ToLower(), ClaimValueTypes.Boolean)
            };

            context.IssuedClaims = claims;

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            System.Console.Write(context.Caller);
            var user = _repository.GetUserById(context.Caller);

            context.IsActive = (user != null) && user.IsActive;
            return Task.FromResult(0);
        }
    }
}
