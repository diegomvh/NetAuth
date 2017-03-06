using System.Collections.Generic;
using IdentityServer4.Models;

namespace NetAuth.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // Console Client Credentials Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes = new List<string>
                    {
                        "api1", "api2"
                    }
                },

                ///////////////////////////////////////////
                // Console Resource Owner Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "roclient",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowedScopes = new List<string>
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                        IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess,

                        "api1", "api2"
                    }
                },

                ///////////////////////////////////////////
                // Console Client Credentials Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "client.custom",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = new List<string>
                    {
                        "custom"
                    },

                    AllowedScopes = new List<string>
                    {
                        "api1", "api2"
                    }
                },

                ///////////////////////////////////////////
                // Introspection Client Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "roclient.reference",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowedScopes = new List<string>
                    {
                        "api1", "api2"
                    },

                    AccessTokenType = AccessTokenType.Reference
                },

                ///////////////////////////////////////////
                // MVC Implicit Flow Samples
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc_implicit",
                    ClientName = "MVC Implicit",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:5000/signin-oidc"
                    },

                    AllowedScopes = new List<string>
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                        "roles",
                        "api1", "api2"
                    }
                },

                ///////////////////////////////////////////
                // JS OAuth 2.0 Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "js_oauth",
                    ClientName = "JavaScript OAuth 2.0 Client",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:28895/index.html"
                    },

                    AllowedScopes = new List<string>
                    {
                        "api1", "api2"
                    }
                },
                
                ///////////////////////////////////////////
                // JS OIDC Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "js_oidc",
                    ClientName = "JavaScript OIDC Client",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:7017/index.html",
                        "http://localhost:7017/silent_renew.html",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:7017/index.html",
                    },

                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:7017"
                    },

                    AllowedScopes = new List<string>
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                        "roles",
                        "api1", "api2"
                    }
                },
            };
        }
    }
}