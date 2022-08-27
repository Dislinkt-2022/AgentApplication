using AgentApplication.WebAPI.Entitites.Model;
using Microsoft.AspNetCore.Identity;

namespace AgentApplication.WebAPI.HostedServices
{
    public class RegisterAdminHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory; 
        private readonly IConfiguration _configuration;

        public RegisterAdminHostedService(
            IServiceScopeFactory scopeFactory, 
            IConfiguration configuration
            )
        {
            _scopeFactory = scopeFactory;
            _configuration = configuration;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var admin = await userManager.FindByNameAsync(_configuration["Administrator:UserName"]);
            if (admin == null)
            {
                var user = new User
                {
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    IsAdmin = true,
                    UserName = _configuration["Administrator:UserName"],
                    Email = _configuration["Administrator:Email"]
                };

                await userManager.CreateAsync(user, _configuration["Administrator:Password"]);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
