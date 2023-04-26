namespace Dtos;

public static class AuthorizationModels
{
    public class LoggedUserDto
    {
        public int UserId { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
