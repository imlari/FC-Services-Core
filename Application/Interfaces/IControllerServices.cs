using Interfaces.Security;

namespace Interfaces;

public interface IControllerServices
{
    IHash hash { get; }
    IPbkdf2Security pbkdf2 { get; }
}
