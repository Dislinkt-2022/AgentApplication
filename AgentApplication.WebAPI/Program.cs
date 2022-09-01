using AgentApplication.WebAPI.Entitites.Model;
using AgentApplication.WebAPI.HostedServices;
using AgentApplication.WebAPI.Services;
using AgentApplication.WebAPI.Services.Interfaces;
using AgentApplication.WebAPI.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

if (Environment.GetEnvironmentVariable("DATABASE_URL") != null && Environment.GetEnvironmentVariable("CORS_ORIGIN") != null)
{
    // Heroku database connection
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    var connectionString = HerokuPostgresConfiguration.ParseConnectionString(databaseUrl);
    
    builder.Services.AddDbContext<CompanyCatalogContext>(options => options.UseNpgsql(connectionString));

    // Heroku CORS
    var corsOrigin = Environment.GetEnvironmentVariable("CORS_ORIGIN");

    builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(new string[] { corsOrigin })
            .AllowAnyMethod()
            .AllowAnyHeader();
    }));
}
else
{
    builder.Services.AddDbContext<CompanyCatalogContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

    builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(builder.Configuration.GetSection("Origins").Value.Split(','))
            .AllowAnyMethod()
            .AllowAnyHeader();
    }));
}

builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

}).AddEntityFrameworkStores<CompanyCatalogContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddHostedService<RegisterAdminHostedService>();
builder.Services.AddHostedService<MigrationService>();

builder.Services.AddScoped<ITokenCreationService, JwtService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }