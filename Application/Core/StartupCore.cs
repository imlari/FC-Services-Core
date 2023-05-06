using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Database.Connections;
using Services;
using Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Library;
using Models.Library;
using Interfaces.Database;
using Interfaces.Security;
using Interfaces;
using Interfaces.Repositories;
using Repositories.Authentication;
using Middleware;

namespace Core;

public delegate void AnotherServices(IServiceCollection services, StartupCore context);
public enum ServiceName
{
    Authentication,
    Feed
}

public class StartupCore
{
    public IConfiguration configuration;
    private AnotherServices? anotherServices;
    private string? prefix;
    private ServiceName serviceName;

    public StartupCore(IConfiguration configuration, ServiceName serviceName)
    {
        this.configuration = configuration;
        this.serviceName = serviceName;
    }

    public StartupCore(IConfiguration configuration, ServiceName serviceName, string prefix) : this(configuration, serviceName)
    { this.prefix = prefix; }

    public StartupCore(IConfiguration configuration, ServiceName serviceName, string prefix, AnotherServices anotherServices) : this(configuration, serviceName, prefix)
    { this.anotherServices = anotherServices; }


    private void ConfigureFeedService(IServiceCollection services)
    {
        services.AddScoped<IFeedDatabase, FeedDatabase>(a => DatabaseFactory.FeedDatabase(this.configuration));
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IHash, Hash>();
        services.AddScoped<IPbkdf2Security, Pbkdf2Security>();
        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<IAuthenticationDatabase, AuthenticationDatabase>(a => DatabaseFactory.AuthenticationDatabase(this.configuration));

        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

        services.AddScoped<ILoggedUser, LoggedUser>();
        services.AddScoped<IControllerServices, ControllerServices>();

        switch (this.serviceName)
        {
            case ServiceName.Authentication: break;
            case ServiceName.Feed: this.ConfigureFeedService(services); break;
            default: throw new NotImplementedException();
        }

        services.AddAuthentication(
            x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(
            x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(JwtService.GetTokenSecret(this.configuration)),
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            }
        );

        if (this.anotherServices is not null)
            this.anotherServices(services, this);
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapControllerRoute(
                name: this.prefix ?? "api",
                pattern: (this.prefix ?? "api") + "/{controller}/{action}"
            );
        });
    }
}
