using System.Collections.Generic;
using IdentityServer4.Models;

namespace NetAuth.Configuration
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> Get()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),

                new IdentityResource
                {
                    Name = "api1",
                    DisplayName = "API 1",
                    Description = "API 1 features and data",

                    UserClaims = new List<string>
                    {
                        "role"
                    }
                },
                new IdentityResource
                {
                    Name = "api2",
                    DisplayName = "API 2",
                    Description = "API 2 features and data, which are better than API 1"
                }
            };
        }
    }
}