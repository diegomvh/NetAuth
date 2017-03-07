using System;
using NetAuthServer.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;

namespace NetAuthServer.Services
{
    public class MongoDbRepository : IRepository
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMongoDatabase _db;
        private const string UsersCollectionName = "Users";
        private const string ClientsCollectionName = "Clients";
        

        public MongoDbRepository(IOptions<MongoDbRepositoryConfiguration> config, IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            var client = new MongoClient(config.Value.ConnectionString);
            _db = client.GetDatabase(config.Value.DatabaseName);
        }

        public User GetUserByUsername(string username)
        {
            System.Console.Write("GetUserByUsername");
            var collection = _db.GetCollection<User>(UsersCollectionName);
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            return collection.Find(filter).SingleOrDefaultAsync().Result;
        }

        public User GetUserById(string id)
        {
            System.Console.Write("GetUserById");
            var collection = _db.GetCollection<User>(UsersCollectionName);
            var filter = Builders<User>.Filter.Eq(u => u.Id, new ObjectId(id));
            return collection.Find(filter).SingleOrDefaultAsync().Result;
        }

        public bool ValidatePassword(string username, string plainTextPassword)
        {
            System.Console.Write("ValidatePassword");
            var user = GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, plainTextPassword);
            switch (result)
            {
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        public Client GetClient(string clientId)
        {
            System.Console.Write("GetClient");
            var collection = _db.GetCollection<Client>(ClientsCollectionName);
            var filter = Builders<Client>.Filter.Eq(x => x.ClientId, clientId);
            return collection.Find(filter).SingleOrDefaultAsync().Result;
        }
    }
}
