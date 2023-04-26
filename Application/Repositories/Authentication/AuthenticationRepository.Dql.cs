using static Dtos.AuthorizationModels;
using static Models.Security.JwtModels;
using static Repositories.Rules.AuthenticationRules;

namespace Repositories.Authentication;

public partial class AuthenticationRepository
{
    public LoggedUserDto Find(FindLoggedUserRule businessRule)
    {


        return new LoggedUserDto();
    }
}
