using ExemploDojo.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace ExemploDojo.IntegrationTests.Fixture
{
    public class BaseTestFixture : IDisposable
    {
        private readonly TestServer Server;

        public HttpClient Client;

        public BaseTestFixture()
        {
            var builder = new WebHostBuilder()
                    .UseStartup<Startup>();

            Server = new TestServer(builder);

            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
    }
}
