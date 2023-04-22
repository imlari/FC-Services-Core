using Interfaces;
using Interfaces.Security;
using Microsoft.AspNetCore.Http;
using Repositories.Interfaces;
using System.Net.Http;
using static Dtos.AuthorizationModels;
using static Models.Security.JwtModels;

namespace Middleware;

public class LoggedUser: ILoggedUser
{
    private readonly IAuthenticationRepository repository;
    private readonly IJwtService jwtService;

    public HttpContext? Context { get; }
    private LoggedUserDto? identifier;

    public LoggedUserDto Identifier
    {
        get
        {
            if (this.Context is null) throw new Exception("Unautorized");
            if (this.identifier is null)
            {
                string token = this.Context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last<string>() ?? string.Empty;

                this.jwtService.Read(token, out ClaimIdentifier claim);
                this.identifier = this.repository.Find(claim);

                if (this.identifier is null) throw new Exception("Unautorized");
            }

            return this.identifier;
        }
    }

    public LoggedUser(IHttpContextAccessor httpContextAcessor, IAuthenticationRepository repository, IJwtService jwtService)
    {
        this.repository = repository;
        this.jwtService = jwtService;

        this.Context = httpContextAcessor.HttpContext;
    }
}
