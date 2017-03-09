using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace NetAuth.Mongo.Models
{
    public class IdentityResource
    {
        public IdentityResource()
        {
        }

        public IdentityResource(string name, IEnumerable<string> claimTypes)
            : this(name, name, claimTypes)
        {
        }

        public IdentityResource(string name, string displayName, IEnumerable<string> claimTypes)
        {
            Name = name;
            DisplayName = displayName;

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
        public bool Emphasize { get; set; } = false;
        public bool Required { get; set; } = false;
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public ICollection<string> UserClaims { get; set; } = new HashSet<string>();
    }
}