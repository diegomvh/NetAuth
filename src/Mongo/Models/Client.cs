using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace NetAuth.Mongo.Models
{
    public class ClientSecret
    {
        
        public string Value { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? Expiration  { get; set; }
    }

    public class ClientClaim
    {
        
        public string Value { get; set; }
        public string Type { get; set; }

    }
    
    public class Client
    {
        public ObjectId Id { get; set; }
        public string ClientId { get; set; }
        public int AbsoluteRefreshTokenLifetime { get; set; } 
        public int AccessTokenLifetime { get; set; } 
        public int AccessTokenType { get; set; } 
        public bool AllowAccessTokensViaBrowser { get; set; } 
        public bool AllowOfflineAccess { get; set; } 
        public bool AllowPlainTextPkce { get; set; } 
        public bool AllowRememberConsent { get; set; } 
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; } 
        public bool AlwaysSendClientClaims { get; set; } 
        public int AuthorizationCodeLifetime { get; set; } 
        public string ClientName { get; set; } 
        public string ClientUri { get; set; } 
        public bool EnableLocalLogin { get; set; } 
        public bool Enabled { get; set; } 
        public int IdentityTokenLifetime { get; set; } 
        public bool IncludeJwtId { get; set; } 
        public string LogoUri { get; set; } 
        public bool LogoutSessionRequired { get; set; } 
        public string LogoutUri { get; set; } 
        public bool PrefixClientClaims { get; set; } 
        public string ProtocolType { get; set; } 
        public int RefreshTokenExpiration { get; set; } 
        public int RefreshTokenUsage { get; set; } 
        public bool RequireClientSecret { get; set; } 
        public bool RequireConsent { get; set; } 
        public bool RequirePkce { get; set; } 
        public int SlidingRefreshTokenLifetime { get; set; } 
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; } 
        public List<string> PostLogoutRedirectUris { get; set; } 
        public List<string> RedirectUris { get; set; } 
        public List<ClientSecret> Secrets { get; set; }
        public List<string> GrantTypes { get; set; }
        public List<string> Scopes { get; set; }
        public List<ClientClaim> Claims { get; set; }
        public List<string> CorsOrigins { get; set; }
        public List<string> IdPRestrictions { get; set; }
    }
}
