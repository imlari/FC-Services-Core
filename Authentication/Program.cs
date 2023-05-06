namespace Authentication;

public static class Program
{
    public static int Main(string[] args)
    {
        try
        {
            CreateHost(args).Build().Run();
            return 0;
        }

        catch (Exception)
        {
            return 1;
        }
    }

    private static IHostBuilder CreateHost(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webhost =>
            {
                webhost.UseStartup<Startup>();
            });
}