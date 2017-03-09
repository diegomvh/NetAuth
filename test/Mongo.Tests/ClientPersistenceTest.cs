using Xunit;

namespace Mongo.Tests
{
    public class ClientPersistenceTest : PersistenceTest
    {
        [Fact]
        public void PassingTest()
        {
            var context = this.GetContext();
            foreach (var c in TestData.Clients()) {
                context.Clients.Add(c);
            }
        }
    }
}
