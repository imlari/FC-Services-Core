using Microsoft.Extensions.Configuration;

namespace Database.Connections;

public class DatabaseFactory
{
    public static int Timeout = 22000;

    public static AuthenticationDatabase AuthenticationDatabase(IConfiguration configuration)
        => new AuthenticationDatabase(configuration.GetConnectionString("") ?? string.Empty, Timeout);

    public static FeedDatabase FeedDatabase(IConfiguration configuration)
        => new FeedDatabase(configuration.GetConnectionString("") ?? string.Empty, Timeout);
}
