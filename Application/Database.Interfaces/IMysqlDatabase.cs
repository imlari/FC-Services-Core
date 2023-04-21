using Models.Database;

namespace Database.Interfaces;

public interface IMysqlDatabase
{
    void Open();
    void Close();
    void Commit();
    void Rollback();

    void Execute(DbExecuteArgument arg);
    T? Execute<T>(DbExecuteScalarArgument args);

    T? Find<T>(DbExecuteArgument arg);
    List<T> ExecuteReader<T>(DbExecuteArgument arg);
}
