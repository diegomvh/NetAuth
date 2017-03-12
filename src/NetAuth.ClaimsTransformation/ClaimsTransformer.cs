using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace NetAuth.ClaimsTransformation
{
    public class ClaimsTransformer : IClaimsTransformer
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
        {
            var identity = (ClaimsIdentity)context.Principal.Identity;
            identity.AddClaim(new Claim("SomeValue", "value"));
            return Task.FromResult(context.Principal);
        }
    }
}