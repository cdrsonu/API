using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using IMDBAppAPI;

namespace SessionDemo.Test
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TestStartup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                .UseEnvironment("Testing")
                .UseStartup<TestStartup>();
        }
    }
}