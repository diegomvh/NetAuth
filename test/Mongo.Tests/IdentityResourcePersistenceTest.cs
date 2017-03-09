using Xunit;

namespace Mongo.Tests
{
    public class IdentityResourcePersistenceTest : PersistenceTest
    {
        [Fact]
        public void PassingTest()
        {
            var context = this.GetContext();
            foreach (var i in TestData.IdentityResources()) {
                context.IdentityResources.Add(i);
            }
        }
    }
}
