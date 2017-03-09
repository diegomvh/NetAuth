using MongoDB.Driver;

namespace NetAuth.Mongo.Repositories
{
    public class IdentityResourceRepository : Repository<NetAuth.Mongo.Models.IdentityResource>
    {
        private const string CollectionName = "IdentityResources";
        
        public IdentityResourceRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            
        }
    }
}
