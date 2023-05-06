
namespace Controller.Models;

public static class AccountModels
{
    public class SingInInput
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}