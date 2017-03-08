using MongoDB.Driver;

namespace NetAuth.IdentityServer.Mongo.Repositories
{
    public class PersistedGrantRepository : Repository<NetAuth.IdentityServer.Mongo.Models.PersistedGrant>
    {
        private const string CollectionName = "PersistedGrants";
        
        public PersistedGrantRepository(IMongoDatabase db) : base(db, CollectionName)
        {
        }
        
    }
}