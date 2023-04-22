using static Dtos.AuthorizationModels;
using static Models.Security.JwtModels;

namespace Interfaces.Repositories;

public interface IAuthenticationRepository
{
    LoggedUserDto Find(ClaimIdentifier claim);
}
