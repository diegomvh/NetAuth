﻿using System.Collections.Generic;
using IdentityServer4.Models;
using MongoDB.Bson;

namespace NetAuth.Models
{
    public class MongoDbClient
    {
        public ObjectId Id { get; set; }
        public string ClientId { get; set; }
        public List<string> RedirectUris { get; set; } 
        public List<string> ClientSecrets { get; set; }
        public IEnumerable<string> GrantTypes { get; set; }
        public List<string> AllowedScopes { get; set; }
    }
}
