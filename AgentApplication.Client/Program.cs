using AgentApplication.Client;
using AgentApplication.Client.Services;
using AgentApplication.Client.Services.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var apiUrl = builder.Configuration.GetValue<string>("ApiUrl");
builder.Services.AddHttpClient("apiClient", client => { client.BaseAddress = new Uri(apiUrl); });

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddMatBlazor();

await builder.Build().RunAsync();
