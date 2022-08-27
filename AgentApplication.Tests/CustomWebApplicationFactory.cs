using AgentApplication.WebAPI.Entitites.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgentApplication.Tests
{
    internal class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private const string ENV = "Tests";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment(ENV);

            builder.ConfigureServices(services =>
            {
                services.AddDbContext<CompanyCatalogContext>(options =>
                {
                    var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
                    options.UseSqlServer(configuration.GetConnectionString("Database"));
                });
            });
        }
    }
}
