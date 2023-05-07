using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Security.Claims;
using System.Text;

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

            string connectionString = "server=containers-us-west-209.railway.app;port=6938;database=railway;user=root;password=5cu1Y8DVEYLMeej8yleH";
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
                command.CommandText = "SELECT Matricula, Nome FROM Empregado WHERE Email = @Email AND Senha = @Senha";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                string matricula = null;
                string nome = null;
                while (reader.Read())
                {
                    matricula = reader["Matricula"].ToString();
                    nome = reader["Nome"].ToString();
                }
                reader.Close();
                connection.Close();

                if (!string.IsNullOrEmpty(matricula) && !string.IsNullOrEmpty(nome))
                {
                    return Ok(new { Matricula = matricula, Nome = nome });
                }
            }
            return BadRequest("Usuário ou senha incorretos");
        }
    }


}