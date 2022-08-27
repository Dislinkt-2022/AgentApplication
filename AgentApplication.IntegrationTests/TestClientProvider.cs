using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace AgentApplication.IntegrationTests
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup(AppDomain.CurrentDomain.GetAssemblies()?.ToString()));

            Client = server.CreateClient();
        }
    }
}
