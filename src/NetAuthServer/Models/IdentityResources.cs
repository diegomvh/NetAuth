using System.Collections.Generic;
using IdentityServer4.Models;
using MongoDB.Bson;

namespace NetAuthServer.Models
{
    public class IdentityResources
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool Emphasize { get; set; }
        public bool Required { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public List<string> Claims { get; set; }
    }
}