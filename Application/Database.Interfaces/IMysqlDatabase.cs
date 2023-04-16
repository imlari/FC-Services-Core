namespace Database.Interfaces;

public interface IMysqlDatabase
{
    void Open();
    void Close();
    void Commit();
    void Rollback();
}
