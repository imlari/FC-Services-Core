using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
namespace backend_squad1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExcluirChamadoController : ControllerBase
    {
        [HttpDelete]
        public IActionResult DeleteChamado()
        {
            return Ok("O chamado foi excluído com sucesso");
        }
    }
}