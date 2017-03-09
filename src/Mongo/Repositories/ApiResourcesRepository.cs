using MongoDB.Driver;

namespace NetAuth.Mongo.Repositories
{
    public class ApiResourcesRepository : Repository<NetAuth.Mongo.Models.ApiResource>
    {
        private const string CollectionName = "ApiResources";
        
        public ApiResourcesRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            
        }
    }
}
