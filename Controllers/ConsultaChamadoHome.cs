using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace backend_squad1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaChamadoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllChamados()
        {
            string connectionString = "server=containers-us-west-209.railway.app;port=6938;database=railway;user=root;password=5cu1Y8DVEYLMeej8yleH";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Chamado";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<ConsultaChamado> chamados = new List<ConsultaChamado>();

            while (reader.Read())
            {
                int idChamado = reader.GetInt32("idChamado");
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
                    idChamado = idChamado.ToString(),
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

                chamados.Add(chamado);
            }

            return Ok(chamados);
        }

    }
}