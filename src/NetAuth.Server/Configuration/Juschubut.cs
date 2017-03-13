using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace NetAuth.Server.Configuration
{
    public class Juschubut
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("serconexcivil-api", "Serconex Civil Api") {
                    UserClaims = new List<string> {"role", "dni"}
                },
                new ApiResource("serconexpenal-api", "Serconex Penal Api") {
                    UserClaims = new List<string> {"role", "dni"}
                },
                new ApiResource("coiron-rw-api", "Coiron Rawson Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("coiron-tw-api", "Coiron Trelew Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("coiron-eq-api", "Coiron Esquel Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("skua-rw-api", "Skua Rawson Api") {
                    UserClaims = new List<string> {"role"},
                    Scopes =
                    {
                        new Scope()
                        {
                            Name = "skua-rw-api.full_access",
                            DisplayName = "Full access to Skua Rawson Api",
                        },
                        new Scope()
                        {
                            Name = "skua-rw-api.read_only",
                            DisplayName = "Read only access to Skua Rawson Api"
                        }
                    }
                },
                new ApiResource("skua-tw-api", "Skua Trelew Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("skua-eq-api", "Skua Esquel Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("siu-rw-api", "Siu Rawson Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("siu-tw-api", "Siu Trelew Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("siu-eq-api", "Siu Esquel Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("libra-rw-api", "Libra Rawson Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("libra-tw-api", "Libra Trelew Api") {
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource("libra-eq-api", "Libra Esquel Api") {
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),

                new IdentityResource()
                {
                    Name = "role",
                    DisplayName = "Role",
                    UserClaims = { "role" }
                },

                new IdentityResource() {
                    Name = "dni",
                    DisplayName = "Documento de identidad",
                    UserClaims = { "dni" }
                }
            };
        }
        public static IEnumerable<Client> Clients()
        {
            return new List<Client>() {
                new Client
                {
                    ClientId = "coiron-mvc",
                    ClientName = "Cliente MVC Coiron",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256())},
                    AllowedScopes = { "role", "coiron-rw-api", "coiron-tw-api", "coiron-eq-api" }
                },
                new Client
                {
                    ClientId = "siu-mvc",
                    ClientName = "Cliente MVC Siu",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256())},
                    AllowedScopes = { "role", "siu-rw-api", "siu-tw-api", "siu-eq-api" }
                },
                new Client
                {
                    ClientId = "skua-mvc",
                    ClientName = "Cliente MVC Skua",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002" },
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile, "role", "skua-rw-api", "skua-tw-api", "skua-eq-api" }
                },
                new Client
                {
                    ClientId = "serconexcivil-mvc",
                    ClientName = "Cliente MVC Serconex Civil",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256())},
                    AllowedScopes = { "role", "dni", "serconexcivil-api", "libra-rw-api", "libra-tw-api", "libra-eq-api" }
                },
                new Client
                {
                    ClientId = "serconexpenal-mvc",
                    ClientName = "Cliente MVC Serconex Penal",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256())},
                    AllowedScopes = { "role", "dni", "serconexpenal-api", "skua-rw-api", "skua-tw-api", "skua-eq-api" }
                }
            };
        }
        public static List<TestUser> TestUsers()
        {
            var users = new List<TestUser>
            {
                new TestUser{SubjectId = "1", Username = "dvanhaaster", Password = "dvanhaaster", 
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Diego van Haaster"),
                        new Claim(JwtClaimTypes.GivenName, "Diego"),
                        new Claim(JwtClaimTypes.FamilyName, "van Haaster"),
                        new Claim(JwtClaimTypes.Email, "dvanhaaster@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Developer"),
                        new Claim(JwtClaimTypes.Role, "Geek"),
                        new Claim(JwtClaimTypes.WebSite, "http://diegomvh.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser{SubjectId = "2", Username = "ecolombres", Password = "ecolombres",
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Eduardo Colombres"),
                        new Claim(JwtClaimTypes.GivenName, "Eduardo"),
                        new Claim(JwtClaimTypes.FamilyName, "Colombres"),
                        new Claim(JwtClaimTypes.Email, "ecolombres@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, "Admin"),
                        new Claim(JwtClaimTypes.Role, "Geek"),
                        new Claim(JwtClaimTypes.WebSite, "http://educolombres.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
            };
            return users;
        }
    }
}