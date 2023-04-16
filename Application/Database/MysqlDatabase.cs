using Database.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace Database;

public class MysqlDatabase : IMysqlDatabase
{
    private string connectionString;
    private int timeout;
    private IDbConnection? connection;
    private IDbTransaction? transaction;

    public MysqlDatabase(string connectionString, int timeout)
    {
        this.connectionString = connectionString;
        this.timeout = timeout;
    }

    private void setConnection()
    {
        if (this.connection is not null) return;
        this.connection = new MySqlConnection(this.connectionString);
    }

    public void Open()
    {
        if (this.connection?.State != ConnectionState.Closed) return;

        this.connection?.Open();
        this.transaction = this.connection?.BeginTransaction();
    }

    public void Close()
    {
        if (this.connection?.State != ConnectionState.Open) return;
        this.transaction?.Rollback();
        this.connection?.Close();

        this.transaction = null;
        this.connection = null;
    }

    public void Commit()
    {
        this.transaction?.Commit();
    }

    public void Rollback()
    {
        this.transaction?.Rollback();
    }
}
