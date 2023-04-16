namespace Authentication;

public static class Program
{
    public static int Main(string[] args)
    {
        var host = CreateHost(args).Build();

        try
        {
            host.Run();
            return 0;
        }

        catch (Exception ex)
        {
            return 1;
        }
    }

    private static IHostBuilder CreateHost(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHost(webhost =>
            {
                webhost.UseStartup<Startup>();
            });
}