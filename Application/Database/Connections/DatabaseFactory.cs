using Microsoft.Extensions.Configuration;

namespace Database.Connections;

public class DatabaseFactory
{
    public static AuthenticationDatabase AuthenticationDatabase(IConfiguration configuration)
        => new AuthenticationDatabase();

    public static FeedDatabase FeedDatabase(IConfiguration configuration)
        => new FeedDatabase();
}
