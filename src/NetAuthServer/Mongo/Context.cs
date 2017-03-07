using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NetAuthServer.Mongo.Models;
using NetAuthServer.Mongo.Repositories;

namespace NetAuthServer.Mongo
{

    public interface IContext
    {
        Repository<TEntity> GetRepository<TEntity>() where TEntity : class;
        bool ValidatePassword(string username, string plainTextPassword);

    }
    public class Context : IContext
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMongoDatabase _db;
        private ClientRepository ClientRepository;
        private UserRepository UserRepository;

        public Context(IOptions<Configuration> config, IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            var client = new MongoClient(config.Value.ConnectionString);
            _db = client.GetDatabase(config.Value.DatabaseName);
        
            this.ClientRepository = new ClientRepository(_db);
            this.UserRepository = new UserRepository(_db);
        }

        public Repository<TEntity> GetRepository<TEntity>() where TEntity : class 
        {
            object repository = null;
            if (typeof(TEntity) == typeof(Client))
            {
                repository = this.ClientRepository;
            }
            else if (typeof(TEntity) == typeof(User))
            {
                repository = this.UserRepository;
            } 
            else 
            {
                var type = typeof(TEntity);
                repository = new Repository<TEntity>(_db, type.Name);
            }
            return repository as Repository<TEntity>;
        }

        public bool ValidatePassword(string username, string plainTextPassword)
        {
            System.Console.Write("ValidatePassword");
            var user = this.UserRepository.GetUserByUsername(username);
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
    }
}