namespace Models.Security;

public static class JwtModels
{
    public class ClaimIdentifier
    {
        public string UserId { get; set; } = string.Empty;

        public int UserIdInt()
        { return Convert.ToInt32(UserId); }

        public static ClaimIdentifier Create(string claim)
            => new ClaimIdentifier { UserId = claim };
    }

    public class TokenCreated
    {
        public DateTime Expire { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
