using static Models.Security.JwtModels;

namespace Interfaces.Security;

public interface IJwtService
{
    void Write(ClaimIdentifier claim, out TokenCreated output);
    void Read(string token, out ClaimIdentifier claim);
}
