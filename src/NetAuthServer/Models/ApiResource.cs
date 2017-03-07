using System.Collections.Generic;
using IdentityServer4.Models;
using MongoDB.Bson;

namespace NetAuthServer.Models
{
    public class ApiScope
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool Emphasize { get; set; }
        public bool Required { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public List<string> Claims { get; set; }
    }
    
    public class ApiSecret
    {
        
        public string Value { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime? Expiration  { get; set; }
    }

    public class ApiResource
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public List<string> Claims { get; set; }
        public List<ApiScope> Scopes { get; set; }
        public List<ApiSecret> Secrets { get; set; }
    }
}