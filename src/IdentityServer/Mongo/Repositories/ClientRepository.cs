using MongoDB.Driver;

namespace NetAuth.IdentityServer.Mongo.Repositories
{
    public class ClientRepository : Repository<NetAuth.IdentityServer.Mongo.Models.Client>
    {
        private const string CollectionName = "Clients";
        
        public ClientRepository(IMongoDatabase db) : base(db, CollectionName)
        {
            
        }

        public NetAuth.IdentityServer.Mongo.Models.Client GetClient(string clientId)
        {
            System.Console.Write("GetClient");
            var filter = Builders<NetAuth.IdentityServer.Mongo.Models.Client>.Filter.Eq(x => x.ClientId, clientId);
            return this.Collection.Find(filter).SingleOrDefaultAsync().Result;
        }
    }
}
