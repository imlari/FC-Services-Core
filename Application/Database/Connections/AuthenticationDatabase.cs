using Interfaces.Database;

namespace Database.Connections;

public class AuthenticationDatabase : MysqlDatabase, IAuthenticationDatabase
{ 
    public AuthenticationDatabase(string ConnectionString, int timeout): base(ConnectionString, timeout) { }
}
