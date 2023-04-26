using static Models.Security.JwtModels;

namespace Repositories.Rules;

public static class AuthenticationRules
{
    public class FindLoggedUserRule
    {
        public ClaimIdentifier Value { get; set; } = new ClaimIdentifier();
    }
}
