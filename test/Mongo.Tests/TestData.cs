using System;
using System.Collections.Generic;
using System.Linq;
using NetAuth.Mongo.Models;

namespace Mongo.Tests
{
    public class TestData
    {
        public static Client ClientAllProperties()
        {
            return new Client()
            {
                AbsoluteRefreshTokenLifetime = 10,
                AccessTokenLifetime = 20,
                AccessTokenType = 1, //AccessTokenType.Reference,
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
                ProtocolType = "", //IdentityServerConstants.ProtocolTypes.OpenIdConnect,
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
                RefreshTokenExpiration = 1, //TokenExpiration.Sliding,
                RefreshTokenUsage = 1, //TokenUsage.ReUse,
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
                },
                UpdateAccessTokenClaimsOnRefresh = true,
                AllowedCorsOrigins = new List<string>() { "CorsOrigin1", "CorsOrigin2", "CorsOrigin3", },
                AllowAccessTokensViaBrowser = false,
                LogoutSessionRequired = false,
                LogoutUri = "somelogouturi"
            };
        }

        private static DateTimeOffset WellKnownTime
        {
            get { return new DateTimeOffset(2000, 1, 1, 1, 1, 1, 0, TimeSpan.Zero); }
        }

        private static Client Client()
        {
            return ClientAllProperties();
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