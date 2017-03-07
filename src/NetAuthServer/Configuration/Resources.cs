using System.Collections.Generic;
using IdentityServer4.Models;

namespace NetAuthServer.Configuration
{
    public class Resources
    {

        public static IEnumerable<ApiResource> GetApi()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API") 
            };
        }

        public static IEnumerable<IdentityResource> GetIdentity()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),

                new IdentityResource
                {
                    Name = "role",
                    UserClaims = { "role" }
                }
            };
        }
    }
}