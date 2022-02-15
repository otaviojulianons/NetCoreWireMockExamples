using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApi.Tests.Settings;
using Xunit;

namespace WebApi.Tests.Controllers
{
    [Collection(nameof(WireMockSharedContext))]
    public class GithubControllerTests : TestContext, IClassFixture<TestWebApplicationFactory>
    {
        public GithubControllerTests(TestWebApplicationFactory webApplicationFactory, WireMockContext wireMockContext) : base(webApplicationFactory, wireMockContext)
        { }

        [Fact]
        public async Task GivenGetUser_WhenFoundUser_ThenReturn200()
        {
            //Act
            var response = await _httpClient.GetAsync("github/users/otaviojulianons");
            var responseText = await response.Content.ReadAsStringAsync();
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("123123", dictionary["id"]);
        }
    }
}
