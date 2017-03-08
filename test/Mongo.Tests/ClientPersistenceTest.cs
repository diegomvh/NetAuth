using NetAuth.Mongo.Models;
using Xunit;

namespace Mongo.Tests
{
    public class ClientPersistenceTest : PersistenceTest
    {
        [Fact]
        public void PassingTest()
        {
            var context = this.GetContext();
            context.Clients.Add(new Client() {});
        }

    }
}
