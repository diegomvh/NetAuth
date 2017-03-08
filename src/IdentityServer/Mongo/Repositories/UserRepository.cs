using MongoDB.Driver;
using MongoDB.Bson;

namespace NetAuth.IdentityServer.Mongo.Repositories
{
    public class UserRepository : Repository<NetAuth.IdentityServer.Mongo.Models.User>
    {
        private const string CollectionName = "Users";
        
        public UserRepository(IMongoDatabase db) : base(db, CollectionName)
        {
        }

        public NetAuth.IdentityServer.Mongo.Models.User GetUserByUsername(string username)
        {
            System.Console.Write("GetUserByUsername");
            var filter = Builders<NetAuth.IdentityServer.Mongo.Models.User>.Filter.Eq(u => u.Username, username);
            return this.Collection.Find(filter).SingleOrDefaultAsync().Result;
        }

        public NetAuth.IdentityServer.Mongo.Models.User GetUserById(string id)
        {
            System.Console.Write("GetUserById");
            var filter = Builders<NetAuth.IdentityServer.Mongo.Models.User>.Filter.Eq(u => u.Id, new ObjectId(id));
            return this.Collection.Find(filter).SingleOrDefaultAsync().Result;
        }

    }
}
