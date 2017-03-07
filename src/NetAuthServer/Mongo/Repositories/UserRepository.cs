using MongoDB.Driver;
using MongoDB.Bson;

namespace NetAuthServer.Mongo.Repositories
{
    public class UserRepository : Repository<NetAuthServer.Mongo.Models.User>
    {
        private const string CollectionName = "Users";
        
        public UserRepository(IMongoDatabase db) : base(db, CollectionName)
        {
        }

        public NetAuthServer.Mongo.Models.User GetUserByUsername(string username)
        {
            System.Console.Write("GetUserByUsername");
            var filter = Builders<NetAuthServer.Mongo.Models.User>.Filter.Eq(u => u.Username, username);
            return this.Collection.Find(filter).SingleOrDefaultAsync().Result;
        }

        public NetAuthServer.Mongo.Models.User GetUserById(string id)
        {
            System.Console.Write("GetUserById");
            var filter = Builders<NetAuthServer.Mongo.Models.User>.Filter.Eq(u => u.Id, new ObjectId(id));
            return this.Collection.Find(filter).SingleOrDefaultAsync().Result;
        }

    }
}
