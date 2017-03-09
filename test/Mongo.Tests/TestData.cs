using System;
using System.Collections.Generic;
using System.Security.Claims;
using NetAuth.Mongo.Models;

namespace Mongo.Tests
{
    public class TestData
    {
        public static IEnumerable<Client> Clients()
        {
            return new List<Client>() 
            {
                ///////////////////////////////////////////
                // Console Client Credentials Flow Sample
                //////////////////////////////////////////
                new Client()
                {
                    ClientId = "client",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret")
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes = new List<string>()
                    {
                        "api1"
                    }
                },

                ///////////////////////////////////////////
                // Console Resource Owner Flow Sample
                //////////////////////////////////////////
                new Client()
                {
                    ClientId = "ro.client",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret")
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowedScopes = new List<string>()
                    {
                        "api1"
                    }
                },

                ///////////////////////////////////////////
                // Console Client Credentials Flow Sample
                //////////////////////////////////////////
                new Client()
                {
                    ClientId = "client.custom",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret")
                    },

                    AllowedGrantTypes = new List<string>()
                    {
                        "custom"
                    },

                    AllowedScopes = new List<string>()
                    {
                        "api1"
                    }
                },

                ///////////////////////////////////////////
                // Introspection Client Sample
                //////////////////////////////////////////
                new Client()
                {
                    ClientId = "roclient.reference",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret")
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowedScopes = new List<string>()
                    {
                        "api1"
                    },

                    AccessTokenType = AccessTokenType.Reference
                },

                ///////////////////////////////////////////
                // MVC Implicit Flow Samples
                //////////////////////////////////////////
                new Client()
                {
                    ClientId = "mvc_implicit",
                    ClientName = "MVC Implicit",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>()
                    {
                        "http://localhost:5000/signin-oidc"
                    },

                    AllowedScopes = new List<string>()
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.Email,
                        "roles",
                        "api1"
                    }
                },

                ///////////////////////////////////////////
                // JS OAuth 2.0 Sample
                //////////////////////////////////////////
                new Client()
                {
                    ClientId = "js_oauth",
                    ClientName = "JavaScript OAuth 2.0 Client",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>()
                    {
                        "http://localhost:28895/index.html"
                    },

                    AllowedScopes = 
                    {
                        "api1"
                    }
                },
                
                ///////////////////////////////////////////
                // JS OIDC Sample
                //////////////////////////////////////////
                new Client()
                {
                    ClientId = "js_oidc",
                    ClientName = "JavaScript OIDC Client",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string>() 
                    {
                        "http://localhost:7017/index.html",
                        "http://localhost:7017/silent_renew.html",
                    },
                    PostLogoutRedirectUris = new List<string>() 
                    {
                        "http://localhost:7017/index.html",
                    },

                    AllowedCorsOrigins = new List<string>() 
                    {
                        "http://localhost:7017"
                    },

                    AllowedScopes = 
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.Email,
                        "roles",
                        "api1"
                    }
                },

                ///////////////////////////////////////////
                // Client all Properties
                //////////////////////////////////////////
                new Client()
                {
                    AbsoluteRefreshTokenLifetime = 10,
                    AccessTokenLifetime = 20,
                    AccessTokenType = AccessTokenType.Reference,
                    EnableLocalLogin = false,
                    AllowRememberConsent = true,
                    AlwaysSendClientClaims = true,
                    AuthorizationCodeLifetime = 30,
                    ClientId = "123",
                    ClientName = "TEST",
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret() {
                            Value = "secret",
                            Description = "secret",
                            Type = "secret type",
                            Expiration = WellKnownTime
                            },
                        new Secret() { Value = "newsecret"},
                    },
                    AllowOfflineAccess = false,
                    AllowPlainTextPkce = false,
                    ProtocolType = ProtocolTypes.OpenIdConnect,
                    RequireClientSecret = true,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = false,
                    ClientUri = "clientUri",
                    AllowedGrantTypes = new List<string>()
                    {
                        "implicit", "hybrid", "authorization_code", "client_credentials", "password"
                    },
                    Enabled = true,
                    IdentityProviderRestrictions = new List<string>() { "idpr" },
                    IdentityTokenLifetime = 40,
                    LogoUri = "uri:logo",
                    PostLogoutRedirectUris = new List<string>() { "uri:logout" },
                    RedirectUris = new List<string>() { "uri:redirect" },
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RequireConsent = true,
                    AllowedScopes = new List<string>() { "restriction1", "restriction2", "restriction3" },
                    SlidingRefreshTokenLifetime = 50,
                    IncludeJwtId = true,
                    PrefixClientClaims = true,
                    Claims = new List<Claim>()
                    {
                        new Claim("client1", "value1"),
                        new Claim("client2", "value2"),
                        new Claim("client3", "value3"),
                        new Claim("client3", "value3", "value3 type")
                    },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AllowedCorsOrigins = new List<string>() { "CorsOrigin1", "CorsOrigin2", "CorsOrigin3", },
                    AllowAccessTokensViaBrowser = false,
                    LogoutSessionRequired = false,
                    LogoutUri = "somelogouturi"
                }
            };
        }

        public static IEnumerable<ApiResource> ApiResources() {
            return new List<ApiResource>()
            {
                new ApiResource("api1", "Some API 1"),
                new ApiResource()
                {
                    Name = "api2",

                    DisplayName = "Some API 2",

                    // secret for using introspection endpoint
                    ApiSecrets = new List<Secret>()
                    {
                        new Secret("secret")
                    },

                    // include the following using claims in access token (in addition to subject id)
                    UserClaims = new List<string>() { JwtClaimTypes.Name, JwtClaimTypes.Email },

                    // this API defines two scopes
                    
                    Scopes = new List<Scope>()
                    {
                        new Scope()
                        {
                            Name = "api2.full_access",
                            DisplayName = "Full access to API 2",
                        },
                        new Scope()
                        {
                            Name = "api2.read_only",
                            DisplayName = "Read only access to API 2"
                        }
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> IdentityResources() {
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
        
        private static DateTime WellKnownTime
        {
            get { return new DateTime(2000, 1, 1, 1, 1, 1, 0, DateTimeKind.Utc); }
        }

        private static List<Claim> Claims(string subjectId)
        {
            return new List<Claim>
            {
                new Claim("sub", subjectId ?? "foo"),
                new Claim("name", "bar"),
                new Claim("email", "baz@qux.com"),
                new Claim("scope", "scope1"),
                new Claim("scope", "scope2"),
                new Claim("guid", "561E12FE7BC24F5E8CAC029B91E8ADE8")
            };
        }

        private static List<Claim> ClientCredentialClaims(string subjectId)
        {
            return new List<Claim>
            {
                new Claim("client_id", subjectId ?? "foo"),
                new Claim("scope", "scope1"),
                new Claim("scope", "scope2"),
                new Claim("guid", "561E12FE7BC24F5E8CAC029B91E8ADE8")
            };
        }
    }
}