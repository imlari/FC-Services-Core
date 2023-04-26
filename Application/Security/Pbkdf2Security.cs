using Interfaces.Security;
using Library;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Models.Library;
using static Models.Security.KeyDerivationModels;

namespace Security;

public sealed class Pbkdf2Security: IPbkdf2Security
{
    private static int numBytes = 8192;

    public Pbkdf2Security() { }

    private KeyDerivationPrf Convert(HashDerivation hashDerivation) => hashDerivation switch
    {
        HashDerivation.HMACSHA512 => KeyDerivationPrf.HMACSHA512,
        HashDerivation.HMACSHA256 => KeyDerivationPrf.HMACSHA256,
        HashDerivation.HMACSHA1 => KeyDerivationPrf.HMACSHA1,
        _ => throw new ArgumentException($"[ERROR HashDerivation] Pbkdf2Security: {hashDerivation.ToString()} is not defined")
    };

    private byte[] DeriveValue(string value, byte[] salt, HashDerivation hashDerivation) =>
        KeyDerivation.Pbkdf2(password: value, salt: salt, prf: Convert(hashDerivation), iterationCount: value.Length * 10, numBytesRequested: numBytes);

    public string Write(string value, HashDerivation hashDerivation)
    {
        var salt = Pbkdf2Utils.GetSaltBytes(value.Length);
        var result = this.DeriveValue(value, salt, hashDerivation);

        return BinaryConverter.ToStringView(Pbkdf2Utils.Write(result, salt), BinaryViewModels.BinaryView.BASE64);
    }

    public bool Verify(string derived, string value, HashDerivation hashDerivation)
    {
        var info = Pbkdf2Utils.Read(BinaryConverter.ToBytesView(derived, BinaryViewModels.BinaryView.BASE64), numBytes);
        var result = this.DeriveValue(value, info.Salt.ToArray(), hashDerivation);

        return BinaryConverter.ToStringView(result, BinaryViewModels.BinaryView.BASE64) == BinaryConverter.ToStringView(info.Derivated.ToArray(), BinaryViewModels.BinaryView.BASE64);
    }
}
