namespace Models.Database;

public class DbExecuteArgument
{
    public DbParameterCollection Parameters { get; set; } = DbParameterCollection.Create();
    public string Sql { get; set; } = string.Empty;
}
