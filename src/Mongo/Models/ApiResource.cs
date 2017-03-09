using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace NetAuth.Mongo.Models
{
    public class ApiSecret
    {
        
        public string Value { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime? Expiration  { get; set; }
    }

    public class ApiResource
    {
        public ApiResource()
        {
        }

        public ApiResource(string name)
            : this(name, name, null)
        {
        }

        public ApiResource(string name, string displayName)
            : this(name, displayName, null)
        {
        }

        public ApiResource(string name, IEnumerable<string> claimTypes)
            : this(name, name, claimTypes)
        {
        }

        public ApiResource(string name, string displayName, IEnumerable<string> claimTypes)
        {
            Name = name;
            DisplayName = displayName;

            Scopes.Add(new Scope(name, displayName));

            if (claimTypes != null && claimTypes.Count() != 0)
            {
                foreach (var type in claimTypes)
                {
                    UserClaims.Add(type);
                }
            }
        }
        public ObjectId Id { get; set; }
        public bool Enabled { get; set; } = true;
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public ICollection<Secret> ApiSecrets { get; set; } = new HashSet<Secret>();
        public ICollection<string> UserClaims { get; set; } = new HashSet<string>();
        public ICollection<Scope> Scopes { get; set; } = new HashSet<Scope>();
    }
}