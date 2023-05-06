using Controller.Models;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[AllowAnonymous]
public class AccountController: ControllerBase
{
    private readonly IControllerServices baseServices;
    
    public AccountController(IControllerServices baseServices)
    {
        this.baseServices = baseServices;
    }

    [HttpPost]
    public IActionResult SingIn([FromBody] AccountModels.SingInInput input)
    {
        return Ok(new
        {
            Email = Convert.ToBase64String(this.baseServices.hash.Update(input.Email)),
            Senha = this.baseServices.pbkdf2.Write(input.Senha, Models.Security.KeyDerivationModels.HashDerivation.HMACSHA512)
        });
    }
}
