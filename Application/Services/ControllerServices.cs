using Interfaces;
using Interfaces.Security;

namespace Services;

public class ControllerServices : IControllerServices
{
    public IHash hash { get; }
    public IPbkdf2Security pbkdf2 { get; }
    public IJwtService jwt { get; }
    public ILoggedUser user { get; }

    public ControllerServices(
        IHash hash,
        IPbkdf2Security pbkdf2,
        IJwtService jwt,
        ILoggedUser user
    )
    {
        this.hash = hash;
        this.pbkdf2 = pbkdf2;
        this.jwt = jwt;
        this.user = user;
    }
}
