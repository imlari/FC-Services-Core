using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace backend_squad1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaChamadoIDController : ControllerBase
    {
        [HttpGet("{id}", Name = "GetChamadoById")]
        public IActionResult GetChamadoById(int id)
        {
            string connectionString = "server=containers-us-west-181.railway.app;port=5947;database=railway;user=root;password=4Fi7NzGpMxBngKKWC1wY";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Chamado WHERE idChamado = @Id";
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string nome = reader.GetString("Nome");
                DateTime dataRelato = reader.GetDateTime("DataRelato");
                string descricao = reader.GetString("Descricao");
                string img = reader.GetString("Img");
                string prioridade = reader.GetString("Prioridade");
                string horarioAbertura = reader.GetString("HorarioAbertura");
                string horarioUltimaAtualizacao = reader.GetString("HorarioUltimaAtualizacao");
                string tipo = reader.GetString("Tipo");
                string status = reader.GetString("Status");
                string tempoDescorrido = reader.GetString("TempoDescorrido");

                ConsultaChamado chamado = new ConsultaChamado
                {
                    idChamado = id.ToString(),
                    Nome = nome,
                    DataRelato = dataRelato,
                    Descricao = descricao,
                    Img = img,
                    Prioridade = prioridade,
                    HorarioAbertura = horarioAbertura,
                    HorarioUltimaAtualizacao = horarioUltimaAtualizacao,
                    Tipo = tipo,
                    Status = status,
                    TempoDescorrido = tempoDescorrido
                };

                return Ok(chamado);
            }
            else
            {
                return NotFound("Chamado não encontrado");
            }
        }
    }
}