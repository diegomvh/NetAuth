using Xunit;

namespace Mongo.Tests
{
    public class ClientPersistenceTest : PersistenceTest
    {
        [Fact]
        public void PassingTest()
        {
            var context = this.GetContext();
            var client = TestData.ClientAllProperties();
            context.Clients.Add(client);
        }
    }
}
