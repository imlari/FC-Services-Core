using Interfaces.Database;
using Interfaces.Repositories;

namespace Repositories.Authentication;

public partial class AuthenticationRepository : IAuthenticationRepository
{
    private IAuthenticationDatabase db;

    public AuthenticationRepository(IAuthenticationDatabase db)
    { this.db = db; }
}
