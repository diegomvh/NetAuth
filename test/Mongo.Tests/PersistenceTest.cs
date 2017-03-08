using MongoDB.Driver;
using NetAuth.Mongo;

namespace Mongo.Tests
{
    public class PersistenceTest
    {
        protected Context GetContext() {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("Test");
            return new Context(db);
        }

    }
}