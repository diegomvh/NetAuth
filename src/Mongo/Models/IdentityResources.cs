// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using System.Linq;

namespace NetAuth.Mongo.Models
{
    public static class JwtClaimTypes
    {
        public const string Subject = "sub";
        public const string AuthorizedParty = "azp";
        public const string AuthenticationTime = "auth_time";
        public const string AuthenticationContextClassReference = "acr";
        public const string SessionId = "sid";
        public const string AuthenticationMethod = "amr";
        public const string IssuedAt = "iat";
        public const string UpdatedAt = "updated_at";
        public const string Expiration = "exp";
        public const string NotBefore = "nbf";
        public const string AccessTokenHash = "at_hash";
        public const string ReferenceTokenId = "reference_token_id";
        public const string Role = "role";
        public const string IdentityProvider = "idp";
        public const string Id = "id";
        public const string Scope = "scope";
        public const string ClientId = "client_id";
        public const string JwtId = "jti";
        public const string Nonce = "nonce";
        public const string AuthorizationCodeHash = "c_hash";
        public const string Issuer = "iss";
        public const string WebSite = "website";
        public const string Picture = "picture";
        public const string Profile = "profile";
        public const string PreferredUserName = "preferred_username";
        public const string NickName = "nickname";
        public const string MiddleName = "middle_name";
        public const string FamilyName = "family_name";
        public const string GivenName = "given_name";
        public const string Name = "name";
        public const string Email = "email";
        public const string Audience = "aud";
        public const string Address = "address";
        public const string PhoneNumberVerified = "phone_number_verified";
        public const string PhoneNumber = "phone_number";
        public const string Locale = "locale";
        public const string ZoneInfo = "zoneinfo";
        public const string BirthDate = "birthdate";
        public const string Gender = "gender";
        public const string EmailVerified = "email_verified";
        public const string Confirmation = "cnf";
    }
    public static class IdentityResources
    {
        public static readonly Dictionary<string, IEnumerable<string>> ScopeToClaimsMapping = new Dictionary<string, IEnumerable<string>>
        {
            { StandardScopes.Profile, new[]
                            { 
                                JwtClaimTypes.Name,
                                JwtClaimTypes.FamilyName,
                                JwtClaimTypes.GivenName,
                                JwtClaimTypes.MiddleName,
                                JwtClaimTypes.NickName,
                                JwtClaimTypes.PreferredUserName,
                                JwtClaimTypes.Profile,
                                JwtClaimTypes.Picture,
                                JwtClaimTypes.WebSite,
                                JwtClaimTypes.Gender,
                                JwtClaimTypes.BirthDate,
                                JwtClaimTypes.ZoneInfo,
                                JwtClaimTypes.Locale,
                                JwtClaimTypes.UpdatedAt 
                            }},
            { StandardScopes.Email, new[]
                            { 
                                JwtClaimTypes.Email,
                                JwtClaimTypes.EmailVerified 
                            }},
            { StandardScopes.Address, new[]
                            {
                                JwtClaimTypes.Address
                            }},
            { StandardScopes.Phone, new[]
                            {
                                JwtClaimTypes.PhoneNumber,
                                JwtClaimTypes.PhoneNumberVerified
                            }},
            { StandardScopes.OpenId, new[]
                            {
                                JwtClaimTypes.Subject
                            }},
        };
        public class OpenId : IdentityResource
        {
            public OpenId()
            {
                Name = StandardScopes.OpenId;
                DisplayName = "Your user identifier";
                Required = true;
                UserClaims.Add(JwtClaimTypes.Subject);
            }
        }

        public class Profile : IdentityResource
        {
            public Profile()
            {
                Name = StandardScopes.Profile;
                DisplayName = "User profile";
                Description = "Your user profile information (first name, last name, etc.)";
                Emphasize = true;
                UserClaims = ScopeToClaimsMapping[StandardScopes.Profile].ToList();
            }
        }

        public class Email : IdentityResource
        {
            public Email()
            {
                Name = StandardScopes.Email;
                DisplayName = "Your email address";
                Emphasize = true;
                UserClaims = ScopeToClaimsMapping[StandardScopes.Email].ToList();
            }
        }

        public class Phone : IdentityResource
        {
            public Phone()
            {
                Name = StandardScopes.Phone;
                DisplayName = "Your phone number";
                Emphasize = true;
                UserClaims = ScopeToClaimsMapping[StandardScopes.Phone].ToList();
            }
        }

        public class Address : IdentityResource
        {
            public Address()
            {
                Name = StandardScopes.Address;
                DisplayName = "Your postal address";
                Emphasize = true;
                UserClaims = ScopeToClaimsMapping[StandardScopes.Address].ToList();
            }
        }
    }
}