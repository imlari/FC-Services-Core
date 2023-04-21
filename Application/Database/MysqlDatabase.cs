using Dapper;
using Database.Interfaces;
using Models.Database;
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

    private DynamicParameters getParameters(DbParameterCollection parameters)
    {
        DynamicParameters param = new DynamicParameters();

        foreach (DbParameter dbParam in parameters.Parameters)
            param.Add(name: dbParam.Name, value: dbParam.Value, direction: dbParam.Direction);

        return param;
    }

    /// <summary>
    ///     find many values
    /// </summary>
    /// <param name="arg"></param>
    public List<T> ExecuteReader<T>(DbExecuteArgument arg)
    {
        return this.connection.Query<T>(
            sql: arg.Sql,
            param: this.getParameters(arg.Parameters),
            transaction: this.transaction,
            commandTimeout: this.timeout
        ).ToList();
    }

    /// <summary>
    ///     find unique value
    /// </summary>
    /// <param name="arg"></param>
    public T? Find<T> (DbExecuteArgument arg)
    {
        var result = this.ExecuteReader<T>(arg);
        return result.FirstOrDefault();
    }

    /// <summary>
    ///     execute used in UPDATE, DELETE OR INSERT if return last inserted id is not necessary
    ///     
    ///     obs: this method not execute commit or rollback, 
    ///         if you value not persisted in database, try execute commit, remember to execute rollback if exception is called
    /// </summary>
    /// <param name="arg"></param>
    public void Execute(DbExecuteArgument arg)
    {
        this.connection.Execute(
            sql: arg.Sql,
            param: this.getParameters(arg.Parameters),
            transaction: this.transaction,
            commandTimeout: this.timeout
        );
    }

    /// <summary>
    ///     execute used in INSERT if return last inserted id is necessary
    ///     
    ///     
    ///     obs: this method not execute commit or rollback, 
    ///         if you value not persisted in database, try execute commit, remember to execute rollback if exception is called
    /// </summary>
    /// <param name="arg"></param>
    public T? Execute<T>(DbExecuteScalarArgument args)
    {
        DynamicParameters outputparameter = new DynamicParameters();
        outputparameter.Add(name: args.Output, direction: ParameterDirection.Output);

        this.Execute(args);
        return this.Find<T>(
            new DbExecuteArgument
            {
                Sql = $"SELECT LAST_INSERT_ID() as '{args.Output}'",
                Parameters = DbParameterCollection.Create().Add(args.Output, direction: ParameterDirection.Output)
            }
        );
    }
}
