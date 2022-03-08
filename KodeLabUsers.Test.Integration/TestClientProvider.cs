using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace KodeLabUsers.Test.Integration
{
    public class TestClientProvider
    {
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>());

            Client = server.CreateClient();
        }

        public HttpClient Client { get; }
    }
}