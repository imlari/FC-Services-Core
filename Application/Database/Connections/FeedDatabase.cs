using Interfaces.Database;

namespace Database.Connections;

public class FeedDatabase : MysqlDatabase, IFeedDatabase
{
    public FeedDatabase(string ConnectionString, int timeout) : base(ConnectionString, timeout) { }
}
