using Xunit;

namespace Mongo.Tests
{
    public class ApiResourcePersistenceTest : PersistenceTest
    {
        [Fact]
        public void PassingTest()
        {
            var context = this.GetContext();
            foreach (var r in TestData.ApiResources()) {
                context.ApiResources.Add(r);
            }
        }
    }
}
