using MongoDB.Driver;
using NetAuth.Mongo;

namespace Mongo.Tests
{
    public class PersistenceTest
    {

        protected IMongoDatabase CreateDataBase() {
            var client = new MongoClient("mongodb://localhost");
            return client.GetDatabase("Test");
        }

        protected Context GetContext() {
            return new Context(this.CreateDataBase());
        }

    }
}