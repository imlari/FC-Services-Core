using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace backend_squad1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroChamadoController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastroChamado(Chamado chamado)
        {
            string connectionString = "server=containers-us-west-209.railway.app;port=6938;database=railway;user=root;password=5cu1Y8DVEYLMeej8yleH";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "INSERT INTO Chamado (Nome, DataRelato, Descricao, Prioridade, HorarioAbertura, horarioUltimaAtualizacao, Status, TempoDecorrido, Empregado_Matricula, Tipo) VALUES (@Nome, @DataRelato, @Descricao, @Prioridade, @HorarioAbertura, @HorarioUltimaAtualizacao, @Status,@TempoDecorrido, @Empregado_Matricula, @Tipo); SELECT LAST_INSERT_ID();";

            command.Parameters.AddWithValue("@Nome", chamado.Nome);
            command.Parameters.AddWithValue("@DataRelato", chamado.DataRelato);
            command.Parameters.AddWithValue("@Descricao", chamado.Descricao);
            command.Parameters.AddWithValue("@Prioridade", chamado.Prioridade);
            command.Parameters.AddWithValue("@HorarioAbertura", chamado.HorarioAbertura);
            command.Parameters.AddWithValue("@HorarioUltimaAtualizacao", chamado.HorarioUltimaAtualizacao);
            command.Parameters.AddWithValue("@Status", chamado.Status);
            command.Parameters.AddWithValue("@TempoDecorrido", chamado.TempoDecorrido);
            command.Parameters.AddWithValue("@Empregado_Matricula", chamado.Empregado_Matricula);
            command.Parameters.AddWithValue("@Tipo", chamado.Tipo);

            connection.Open();



            return Ok(chamado);
        }
    }
}
