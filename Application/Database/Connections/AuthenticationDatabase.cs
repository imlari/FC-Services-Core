using Database.Interfaces;

namespace Database.Connections;

public class AuthenticationDatabase : MysqlDatabase, IAuthenticationDatabase
{ 
    public AuthenticationDatabase(string ConnectionString, int timeout): base(ConnectionString, timeout) { }
}
