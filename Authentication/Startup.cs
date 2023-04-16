using Core;

namespace Authentication;

public class Startup: StartupCore
{
    public Startup(IConfiguration configuration) : base(configuration, "auth") { }
}
