using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.MongoDB.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace NetAuth.Server.Mongo
{
    public interface IMongoRepository {
        IMongoCollection<MongoUser> Users { get; set; }
        bool ValidateCredentials(string username, string password);
        MongoUser FindByUsername(string username);
        MongoUser FindByExternalProvider(string provider, string userId);
        MongoUser AutoProvisionUser(string provider, string userId, IEnumerable<Claim> claims);
    }

    public class MongoRepository : IMongoRepository
    {
        public readonly IMongoDatabase Database;
        public IMongoCollection<MongoUser> Users { get; set; }

        public MongoRepository(IOptions<MongoOptions> mongoOptions)
        {
            var client = new MongoClient(mongoOptions.Value.ConnectionString);
            Database = client.GetDatabase(mongoOptions.Value.DatabaseName);
            Users = Database.GetCollection<MongoUser>("Users");
        }

        public bool ValidateCredentials(string username, string password)
        {
            var user = this.Users.Find(u => u.Username == username).FirstOrDefault();
            return user.Password == password;
        }

        public MongoUser FindByUsername(string username)
        {
            return this.Users.Find(u => u.Username == username).FirstOrDefault();
        }

        public MongoUser FindByExternalProvider(string provider, string userId)
        {
            throw new NotImplementedException();
        }

        public MongoUser AutoProvisionUser(string provider, string userId, IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}