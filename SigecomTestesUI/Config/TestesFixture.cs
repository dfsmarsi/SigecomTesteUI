using SigecomTestesUI.Services;
using Xunit;

namespace SigecomTestesUI.Config
{
    [CollectionDefinition(nameof(TestesFixtureCollection))]
    public class TestesFixtureCollection : ICollectionFixture<TestesFixture> { }

    public class TestesFixture
    {
        public DriverService DriverService;

        public TestesFixture()
        {
            DriverService = new DriverService();
        }
    }
}
