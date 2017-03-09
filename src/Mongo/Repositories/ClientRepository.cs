using MongoDB.Driver;

namespace NetAuth.Mongo.Repositories
{
    public class ClientRepository : Repository<NetAuth.Mongo.Models.Client>
    {
        private const string CollectionName = "Clients";
        
        public ClientRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            
        }
    }
}
