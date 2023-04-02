using Microsoft.AspNetCore.Mvc;

namespace backend_squad1.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{

 

[HttpPost(Name = "Adicionar Usuario")]
public IActionResult PostUser([FromBody] Usuario user)
{
    // Adicionar o usuário no banco de dados
    return Ok();
}
}