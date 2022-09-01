using AgentApplication.WebAPI.Entitites.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AgentApplication.WebAPI.HostedServices
{
    public class MigrationService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public MigrationService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Applying migrations");

            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CompanyCatalogContext>();
            await context.Database.MigrateAsync();

            Console.WriteLine("Done");
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
