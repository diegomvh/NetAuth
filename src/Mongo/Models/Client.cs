using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace NetAuth.Mongo.Models
{

    #region From IdentityServerConstants
    // From IdentityServerConstants
    public static class ProtocolTypes
    {
        public const string OpenIdConnect = "oidc";
        public const string WsFederation = "wsfed";
        public const string Saml2p = "saml2p";
    }
    public static class SecretTypes
    {
        public const string SharedSecret = "SharedSecret";
        public const string X509CertificateThumbprint = "X509Thumbprint";
        public const string X509CertificateName = "X509Name";
        public const string X509CertificateBase64 = "X509CertificateBase64";
    }
    #endregion

    public class Secret
    {
        public Secret()
        {
            Type = SecretTypes.SharedSecret;
        }

        public Secret(string value, DateTime? expiration = null)
            : this()
        {
            Value = value;
            Expiration = expiration;
        }

        public Secret(string value, string description, DateTime? expiration = null)
            : this()
        {
            Description = description;
            Value = value;
            Expiration = expiration;
        }

        public string Value { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? Expiration  { get; set; }
    }

    public class Claim
    {

        public Claim(string type, string value) { Type = type; Value = value; }
        
        public string Type { get; set; }   
        public string Value { get; set; }

    }
    
    public class Client
    {
        public ObjectId Id { get; set; }
        public string ClientId { get; set; }
        public AccessTokenType AccessTokenType { get; set; } = AccessTokenType.Jwt;
        public string ClientName { get; set; } 
        public string ClientUri { get; set; } 
        public bool EnableLocalLogin { get; set; } = true;
        public bool Enabled { get; set; } = true;
        public int IdentityTokenLifetime { get; set; } = 300;
        public int AccessTokenLifetime { get; set; } = 3600;
        public int AuthorizationCodeLifetime { get; set; } = 300;
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;
        public bool IncludeJwtId { get; set; } = false;
        public string LogoUri { get; set; } 
        public string LogoutUri { get; set; } 
        public string ProtocolType { get; set; } = ProtocolTypes.OpenIdConnect;
        public TokenExpiration RefreshTokenExpiration { get; set; } = TokenExpiration.Absolute;
        public TokenUsage RefreshTokenUsage { get; set; } = TokenUsage.OneTimeOnly;
        public bool RequireClientSecret { get; set; } = true;
        public bool RequireConsent { get; set; } = true;
        public bool AllowRememberConsent { get; set; } = true;
        public bool RequirePkce { get; set; } = false;
        public bool AllowPlainTextPkce { get; set; }  = false;
        public bool AllowAccessTokensViaBrowser { get; set; } = false;
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; } = false;
        public IEnumerable<string> PostLogoutRedirectUris { get; set; } = new HashSet<string>();
        public bool LogoutSessionRequired { get; set; } = true;
        public ICollection<string> RedirectUris { get; set; } = new HashSet<string>();
        public ICollection<Secret> ClientSecrets { get; set; } = new HashSet<Secret>();
        public IEnumerable<string> AllowedGrantTypes { get; set; } = GrantTypes.Implicit;
        public bool AllowOfflineAccess { get; set; }  = false;
        public ICollection<string> AllowedScopes { get; set; } = new HashSet<string>();
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; } = false;
        public ICollection<Claim> Claims { get; set; } = new HashSet<Claim>();
        public bool AlwaysSendClientClaims { get; set; } = false;
        public bool PrefixClientClaims { get; set; } = true;
        public ICollection<string> AllowedCorsOrigins { get; set; } = new HashSet<string>();
        public ICollection<string> IdentityProviderRestrictions { get; set; } = new HashSet<string>();
    }
}
