using static Dtos.AuthorizationModels;
using static Models.Security.JwtModels;
using static Repositories.Rules.AuthenticationRules;

namespace Interfaces.Repositories;

public interface IAuthenticationRepository
{
    LoggedUserDto? Find(FindLoggedUserRule claim);
}
