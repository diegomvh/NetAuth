using MongoDB.Driver;

namespace NetAuth.Mongo.Repositories
{
    public class PersistedGrantRepository : Repository<NetAuth.Mongo.Models.PersistedGrant>
    {
        private const string CollectionName = "PersistedGrants";
        
        public PersistedGrantRepository(IMongoDatabase db) : base(db, CollectionName)
        {
        }
        
    }
}