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
            return new Client
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
                IdentityProviderRestrictions = new[] { "idpr" }.ToList(),
                IdentityTokenLifetime = 40,
                LogoUri = "uri:logo",
                PostLogoutRedirectUris = { "uri:logout" },
                RedirectUris = { "uri:redirect" },
                RefreshTokenExpiration = 1, //TokenExpiration.Sliding,
                RefreshTokenUsage = 1, //TokenUsage.ReUse,
                RequireConsent = true,
                AllowedScopes = { "restriction1", "restriction2", "restriction3" },
                SlidingRefreshTokenLifetime = 50,
                IncludeJwtId = true,
                PrefixClientClaims = true,
                Claims = new List<Claim>
                {
                    new Claim("client1", "value1"),
                    new Claim("client2", "value2"),
                    new Claim("client3", "value3"),
                    new Claim("withType", "value", "typeOfValue")
                },
                UpdateAccessTokenClaimsOnRefresh = true,
                AllowedCorsOrigins = new List<string> { "CorsOrigin1", "CorsOrigin2", "CorsOrigin3", },
                AllowAccessTokensViaBrowser = false,
                LogoutSessionRequired = false,
                LogoutUri = "somelogouturi"
            };
        }

        public static Scope ScopeAllProperties()
        {
            return new Scope
            {
                Name = "all",
                DisplayName = "displayName",
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim
                    {
                        Name = "claim1",
                        AlwaysIncludeInIdToken = false,
                        Description = "claim1 description"
                    },
                    new ScopeClaim
                    {
                        Name = "claim2",
                        AlwaysIncludeInIdToken = true,
                        Description = "claim2 description"
                    },
                },
                ClaimsRule = "claimsRule",
                Description = "Description",
                Emphasize = true,
                Enabled = false,
                IncludeAllClaimsForUser = true,
                Required = true,
                ShowInDiscoveryDocument = false,
                Type = ScopeType.Identity,
                AllowUnrestrictedIntrospection = true,
                ScopeSecrets = new List<Secret>() {
                    new Secret("secret1"),
                    new Secret("secret2", "description", new DateTimeOffset(2000, 1, 1, 1, 1, 1, 1, TimeSpan.Zero))}
            };
        }

        public static Scope ScopeMandatoryProperties()
        {
            return new Scope
            {
                Name = "mandatory",
                DisplayName = "displayName"
            };
        }

        public static AuthorizationCode AuthorizationCode(string subjectId = null)
        {
            var ac = AuthorizationCodeWithoutNonce(subjectId);
            ac.Nonce = "test";
            return ac;
        }

        public static AuthorizationCode AuthorizationCodeWithoutNonce(string subjectId = null)
        {
            return new AuthorizationCode
            {
                IsOpenId = true,
                CreationTime = WellKnownTime,
                Client = Client(),
                RedirectUri = "uri:redirect",
                RequestedScopes = Scopes(),
                Subject = Subject(subjectId),
                WasConsentShown = true,
                CodeChallenge = "codeChallenge",
                CodeChallengeMethod = "challengeMethod",
                SessionId = "sessionId"
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

        public static IEnumerable<Scope> Scopes()
        {
            yield return ScopeAllProperties();
            yield return ScopeMandatoryProperties();
        }

        private static ClaimsPrincipal Subject(string subjectId)
        {
            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    Claims(subjectId), "authtype"
                    ));
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
                new Claim("guid", "561E12FE7BC24F5E8CAC029B91E8ADE8"),
                new Claim("valueType", "value", "typeOfValue")
            };
        }

        private static List<Claim> ClientCredentialClaims(string subjectId)
        {
            return new List<Claim>
            {
                new Claim("client_id", subjectId ?? "foo"),
                new Claim("scope", "scope1"),
                new Claim("scope", "scope2"),
                new Claim("guid", "561E12FE7BC24F5E8CAC029B91E8ADE8"),
                new Claim("valueType", "value", "typeOfValue")
            };
        }

        public static RefreshToken RefreshToken(string subject = null)
        {
            return new RefreshToken
            {
                AccessToken = Token(subject),
                CreationTime = new DateTimeOffset(2000, 1, 1, 1, 1, 1, 0, TimeSpan.Zero),
                LifeTime = 100,
                Version = 10,
                Subject = new ClaimsPrincipal(new ClaimsIdentity(Claims(subject)))
            };
        }

        public static Token Token(string subject = null)
        {
            return new Token
            {
                Audience = "audience",
                Claims = Claims(subject),
                Client = ClientAllProperties(),
                CreationTime = new DateTimeOffset(2000, 1, 1, 1, 1, 1, 0, TimeSpan.Zero),
                Issuer = "issuer",
                Lifetime = 200,
                Type = "tokenType",
                Version = 10
            };
        }

        public static Token ClientCredentialsToken(string client = null)
        {
            return new Token
            {
                Audience = "audience",
                Claims = ClientCredentialClaims(client),
                Client = ClientAllProperties(),
                CreationTime = new DateTimeOffset(2000, 1, 1, 1, 1, 1, 0, TimeSpan.Zero),
                Issuer = "issuer",
                Lifetime = 200,
                Type = "tokenType",
                Version = 10
            };
        }
    }
}