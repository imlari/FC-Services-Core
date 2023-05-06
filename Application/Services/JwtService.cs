using static Models.Security.JwtModels;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Library;
using Models.Library;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Interfaces.Security;

namespace Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration Configuration;
#if DEBUG
    private static string prefix = "Secret:";
#elif RELEASE
    private static string prefix = "EnvSecret";
#endif

    public JwtService(IConfiguration Configuration)
    { this.Configuration = Configuration; }

    public static string GetEnv(string Identifier) => $"{prefix}{Identifier}";

    public static byte[] GetTokenSecret(IConfiguration configuration)
    { return BinaryConverter.ToBytesView(configuration.GetSection(GetEnv("Key")).Value ?? "", BinaryViewModels.BinaryView.BASE64); }

    private int GetTotalMinutes()
    {
        try { return Convert.ToInt32(this.Configuration.GetSection(GetEnv("Minutes")).Value); }
        catch { return 60; }
    }

    public void Write(ClaimIdentifier claim, out TokenCreated output)
    {
        output = new TokenCreated { Expire = DateTime.UtcNow.AddMinutes(this.GetTotalMinutes()) };

        SecurityTokenDescriptor descriptor = new()
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, $"{claim.UserId}") }),
            Expires = output.Expire,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(GetTokenSecret(this.Configuration)), SecurityAlgorithms.HmacSha256Signature)
        };
        JwtSecurityTokenHandler handler = new();
        output.Token = handler.WriteToken(handler.CreateToken(descriptor));
    }

    public void Read(string token, out ClaimIdentifier claim)
    {
        try
        {
            JwtSecurityTokenHandler handler = new();
            handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(GetTokenSecret(this.Configuration)),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            JwtSecurityToken jwt = (JwtSecurityToken)validatedToken;
            claim = ClaimIdentifier.Create(jwt.Claims.Where(a => a.Type == "nameid").FirstOrDefault()?.Value ?? string.Empty);
        }
        catch (Exception error)
        { throw new Exception($"INVALID TOKEN {error.Message}", error); }
    }
}
