using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace backend_squad1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostLogin([FromBody] LoginRequest login)
        {
            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Senha))
            {
                return BadRequest("Email e senha são obrigatórios");
            }

            string connectionString = "server=containers-us-west-181.railway.app;port=5947;database=railway;user=root;password=4Fi7NzGpMxBngKKWC1wY";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT COUNT(*) FROM Empregado WHERE Email = @Email AND Senha = @Senha";
            command.Parameters.AddWithValue("@Email", login.Email);
            command.Parameters.AddWithValue("@Senha", login.Senha);
            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            if (count == 1)
            {
                string token = GerarTokenJWT(login.Email);
                return Ok(new { token });
            }

            return BadRequest("Usuário ou senha incorretos");
        }

        private string GerarTokenJWT(string email)
{
    string chaveSecreta = "minha-chave-secreta-123";
    var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));

    // Definir as informações do usuário que serão adicionadas ao token
    var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    // Definir as configurações do token, incluindo a duração e a chave de assinatura
    var tokenConfig = new JwtSecurityToken(
        issuer: "minha-empresa.com",
        audience: "minha-empresa.com",
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256)
    );

    // Gerar o token como uma string
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenString = tokenHandler.WriteToken(tokenConfig);

    return tokenString;
}
    }


}