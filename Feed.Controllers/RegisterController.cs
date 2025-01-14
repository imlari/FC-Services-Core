using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
namespace backend_squad1.Controllers;

[ApiController]
[Route("[controller]")]


public class CadastrarUsuarioController : ControllerBase
{



    [HttpPost(Name = "Adicionar Usuario")]


    public IActionResult PostCadastrarEmpregado([FromBody] Empregado user)
    {

        string connectionString = "server=containers-us-west-181.railway.app;port=5947;database=railway;user=root;password=4Fi7NzGpMxBngKKWC1wY";
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlCommand command = connection.CreateCommand();

        command.CommandText = "SELECT COUNT(*) FROM Empregado WHERE Matricula = @Matricula";
        command.Parameters.AddWithValue("@Matricula", user.Matricula);
        connection.Open();
        int count = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();

        // Se a matrícula já existe, retornar um erro
        if (count > 0)
        {
            return BadRequest("Usuário já cadastrado");
        }
        if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Senha))
        {
            return BadRequest("Email e senha são obrigatórios");
        }

        command.CommandText = "INSERT INTO Empregado (Matricula, Nome, Funcao, Email, Senha) VALUES (@Matricula, @Nome, @Funcao, @Email, @Senha)";
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@Matricula", user.Matricula);
        command.Parameters.AddWithValue("@Nome", user.Nome);
        command.Parameters.AddWithValue("@Funcao", user.Funcao);
        command.Parameters.AddWithValue("@Email", user.Email);
        command.Parameters.AddWithValue("@Senha", user.Senha);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        return Ok();
    }
}