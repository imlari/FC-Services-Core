namespace Models.Database;

public class DbExecuteScalarArgument: DbExecuteArgument
{
    private string output = string.Empty;
    public string Output
    {
        get { return output; }
        set { output = (value.Substring(0, 1) == "@") ? value : $"@{value}"; }
    }
}
