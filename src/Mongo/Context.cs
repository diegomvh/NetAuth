using MongoDB.Driver;
using NetAuth.Mongo.Repositories;

namespace NetAuth.Mongo
{

    public interface IContext
    {

    }
    public class Context : IContext
    {
        private readonly IMongoDatabase _db;
        public ClientRepository Clients;
        public UserRepository Users;
        public PersistedGrantRepository PersistedGrants;
        public ApiResourceRepository ApiResources;
        public IdentityResourceRepository IdentityResources;


        public Context(IMongoDatabase db)
        {
            _db = db;
            this.Clients = new ClientRepository(_db);
            this.Users = new UserRepository(_db);
            this.PersistedGrants = new PersistedGrantRepository(_db);
            this.ApiResources = new ApiResourceRepository(_db);
            this.IdentityResources = new IdentityResourceRepository(_db);
        }
    }
}