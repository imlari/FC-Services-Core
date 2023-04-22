using Microsoft.AspNetCore.Http;
using static Dtos.AuthorizationModels;

namespace Interfaces;

public interface ILoggedUser
{
    HttpContext? Context { get; }
    LoggedUserDto Identifier { get; }
}
