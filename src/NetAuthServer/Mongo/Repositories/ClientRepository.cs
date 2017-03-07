using MongoDB.Driver;

namespace NetAuthServer.Mongo.Repositories
{
    public class ClientRepository : Repository<NetAuthServer.Mongo.Models.Client>
    {
        private const string CollectionName = "Clients";
        
        public ClientRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            
        }

        public NetAuthServer.Mongo.Models.Client GetClient(string clientId)
        {
            System.Console.Write("GetClient");
            var filter = Builders<NetAuthServer.Mongo.Models.Client>.Filter.Eq(x => x.ClientId, clientId);
            return this.Collection.Find(filter).SingleOrDefaultAsync().Result;
        }
    }
}
