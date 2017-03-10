using System;
using System.Collections.Generic;
using System.Security.Claims;
using MongoDB.Bson;

namespace NetAuth.Server.Mongo
{
    public class MongoUser
    {
        public ObjectId Id { get; set; }
        public Guid? Guid { get; set; }
        public string Sid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<string> Organizations { get; set; }
        public ICollection<Claim> Claims { get; set; } = new HashSet<Claim>();
    }
}