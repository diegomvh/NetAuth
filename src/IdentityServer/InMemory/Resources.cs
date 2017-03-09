using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace NetAuth.IdentityServer.InMemory
{
    public class Resources
    {

        public static IEnumerable<ApiResource> GetApi()
        {
            return new List<ApiResource>()
            {
                new ApiResource("api1", "Some API 1"),
                new ApiResource
                {
                    Name = "api2",

                    DisplayName = "Some API 2",

                    // secret for using introspection endpoint
                    ApiSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // include the following using claims in access token (in addition to subject id)
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email },

                    // this API defines two scopes
                    
                    Scopes =
                    {
                        new Scope()
                        {
                            Name = "api2.full_access",
                            DisplayName = "Full access to API 2",
                        },
                        new Scope
                        {
                            Name = "api2.read_only",
                            DisplayName = "Read only access to API 2"
                        }
                    }
                }
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
                new IdentityResources.Address(),

                new IdentityResource
                {
                    Name = "role",
                    DisplayName = "Role",
                    UserClaims = { "role" }
                }
            };
        }
    }
}