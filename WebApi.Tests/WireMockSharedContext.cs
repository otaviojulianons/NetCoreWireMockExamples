using Xunit;

namespace WebApi.Tests.Settings
{
    [CollectionDefinition(nameof(WireMockSharedContext))]
    public class WireMockSharedContext : ICollectionFixture<WireMockContext>
    { }
}
