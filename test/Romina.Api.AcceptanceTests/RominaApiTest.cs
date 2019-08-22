using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Xunit;


namespace Romina.Api.AcceptanceTests
{
    public class RominaApiTest
    {

        [Fact]
        public async Task Get_Returns_Product()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("C:\\dev\\Romina\\Romina.Api\\appsettings.json")
                .Build();

            var webHostBuilder = new WebHostBuilder()
                .UseConfiguration(config)
                .UseStartup<Startup>();
            using (var server = new TestServer(webHostBuilder))
            {
                using (var client = server.CreateClient())
                {
                    var result = await client.GetAsync("api/product/abc");

                    Assert.True(result.IsSuccessStatusCode);
                }
            }            
        }
    }
}
