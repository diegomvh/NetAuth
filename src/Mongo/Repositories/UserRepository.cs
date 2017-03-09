using MongoDB.Driver;
using MongoDB.Bson;

namespace NetAuth.Mongo.Repositories
{
    public class UserRepository : Repository<NetAuth.Mongo.Models.User>
    {
        private const string CollectionName = "Users";
        
        public UserRepository(IMongoDatabase db) : base(db, CollectionName)
        {
        }
    }
}
