using System;
using System.Linq;
using WireMock.Server;
using WireMock.Settings;

namespace WebApi.Tests.Settings
{
    public class WireMockContext : IDisposable
    {
        public string WireMockHost { get; private set; }
        public static WireMockServer WireMockServer { get; private set; }

        public WireMockContext()
        {
            SetupWireMockServer();

            WireMockHost = WireMockServer.Urls.FirstOrDefault();
        }

        private void SetupWireMockServer()
        {
            var settings = new WireMockServerSettings()
            {
                ReadStaticMappings = true,
                WatchStaticMappingsInSubdirectories = true
            };
            WireMockServer = WireMockServer.Start(settings);
            WireMockServer.ReadStaticMappings("Mappings/");
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                WireMockServer.Stop();
                WireMockServer.Dispose();
            }
        }
    }
}
