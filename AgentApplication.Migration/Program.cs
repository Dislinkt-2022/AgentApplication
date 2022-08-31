using AgentApplication.Migration;
using AgentApplication.WebAPI.Entitites.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Applying migrations");
var webHost = new WebHostBuilder()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseStartup<ConsoleStartup>()
    .Build();

using (var context = (CompanyCatalogContext)webHost.Services.GetService(typeof(CompanyCatalogContext)))
{
    context.Database.Migrate();
}

Console.WriteLine("Done");
Thread.Sleep(TimeSpan.FromHours(1));
