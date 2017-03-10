using System.Collections.Generic;
using IdentityServer4.Models;

namespace NetAuth.Configuration
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
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
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
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256())},
                    AllowedScopes = { "role", "skua-rw-api", "skua-tw-api", "skua-eq-api" }
                },
                new Client
                {
                    ClientId = "serconexcivil-mvc",
                    ClientName = "Cliente MVC Serconex Civil",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
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
    }
}