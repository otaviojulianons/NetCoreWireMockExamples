using System;
using System.Net.Http;

namespace WebApi.Tests.Settings
{
    public abstract class TestContext : IDisposable
    {

        protected readonly HttpClient _httpClient;
        private readonly WireMockContext _wireMockContext;

        public TestContext(TestWebApplicationFactory factory, WireMockContext wireMockContext)
        {
            _wireMockContext = wireMockContext;

            SetupVariaveisAmbiente();

            _httpClient = factory.CreateClient();
        }

        private void SetupVariaveisAmbiente()
        {
            string requestUrl = _wireMockContext.WireMockHost;

            Environment.SetEnvironmentVariable("Github:Url", requestUrl);
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _httpClient.Dispose();
        }
    }
}
