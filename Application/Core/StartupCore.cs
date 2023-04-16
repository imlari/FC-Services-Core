using Database.Interfaces;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Database.Connections;

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

    public StartupCore(IConfiguration configuration, ServiceName serviceName, string prefix): this(configuration, serviceName)
    { this.prefix = prefix; }

    public StartupCore(IConfiguration configuration, ServiceName serviceName, string prefix, AnotherServices anotherServices): this(configuration, serviceName, prefix)
    { this.anotherServices = anotherServices; }

    private void ConfigureAuthenticationService(IServiceCollection services)
    {
        services.AddScoped<IAuthenticationDatabase, AuthenticationDatabase>(a => DatabaseFactory.AuthenticationDatabase(this.configuration));
    }

    private void ConfigureFeedService(IServiceCollection services)
    {
        services.AddScoped<IFeedDatabase, FeedDatabase>(a => DatabaseFactory.FeedDatabase(this.configuration));
    }

    public void ConfigureServices (IServiceCollection services)
    {
        services.AddControllers ();
        services.AddHttpContextAccessor();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        switch(this.serviceName)
        {
            case ServiceName.Authentication: this.ConfigureAuthenticationService(services); break;
            case ServiceName.Feed: this.ConfigureFeedService(services); break;
        }

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
                pattern: String.Format("/{0}{1}", (this.prefix ?? "api"), "/{controller}/{action}")
            );
        });
    }
}
