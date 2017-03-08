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
        private ClientRepository Clients;
        private UserRepository Users;

        public Context(IMongoDatabase db)
        {
            _db = db;
            this.Clients = new ClientRepository(_db);
            this.Users = new UserRepository(_db);
        }
    }
}