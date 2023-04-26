using static Models.Security.KeyDerivationModels;

namespace Interfaces.Security;

public interface IPbkdf2Security
{
    string Write(string value, HashDerivation hashDerivation);
    bool Verify(string derived, string value, HashDerivation hashDerivation);
}
