using MongoDB.Driver;

namespace NetAuth.Mongo.Repositories
{
    public class ApiResourceRepository : Repository<NetAuth.Mongo.Models.ApiResource>
    {
        private const string CollectionName = "ApiResources";
        
        public ApiResourceRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            
        }
    }
}
