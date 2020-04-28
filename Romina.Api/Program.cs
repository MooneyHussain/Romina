using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Romina.Api
{
    public class Program
    {
        // entry point of the system 
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        // builds up a host for our app (this is boilerplate stuff from microsoft)
        // does a bunch of 'default' things like add appsettings.json as a source of info
        // it uses our Startup class to add any additional bindings / other things we set up 
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
