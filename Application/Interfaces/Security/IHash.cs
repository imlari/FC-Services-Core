using Models.Library;
using static Models.Security.HashModels;

namespace Interfaces.Security;

public interface IHash
{
    IHash Create(AppHashAlgorithm cipher);
    byte[] Update(byte[] value);
    byte[] Update(string value);
}
