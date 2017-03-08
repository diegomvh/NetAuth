using MongoDB.Driver;

namespace NetAuth.Mongo.Repositories
{
    public class ClientRepository : Repository<NetAuth.Mongo.Models.Client>
    {
        private const string CollectionName = "Clients";
        
        public ClientRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            
        }

        public NetAuth.Mongo.Models.Client GetClient(string clientId)
        {
            System.Console.Write("GetClient");
            var filter = Builders<NetAuth.Mongo.Models.Client>.Filter.Eq(x => x.ClientId, clientId);
            return this.Collection.Find(filter).SingleOrDefaultAsync().Result;
        }
    }
}
