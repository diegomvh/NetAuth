using MongoDB.Driver;

namespace NetAuthServer.Mongo.Repositories
{
    public class PersistedGrantRepository : Repository<NetAuthServer.Mongo.Models.PersistedGrant>
    {
        private const string CollectionName = "PersistedGrants";
        
        public PersistedGrantRepository(IMongoDatabase db) : base(db, CollectionName)
        {
        }
        
    }
}