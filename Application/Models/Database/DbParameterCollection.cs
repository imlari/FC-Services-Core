using System.Data;

namespace Models.Database;

public class DbParameterCollection
{
    public List<DbParameter> Parameters { get; } = new List<DbParameter>();

    private DbParameterCollection() { }

    public DbParameterCollection Add(string name, object? value, ParameterDirection direction)
    {
        this.Parameters.Add(
            new DbParameter
            {
                Name = name,
                Value = value,
                Direction = direction
            }
        );
        return this;
    }

    public DbParameterCollection Add(string name, ParameterDirection direction)
    {
        this.Parameters.Add(
            new DbParameter
            {
                Name = name,
                Value = null,
                Direction = direction
            }
        );
        return this;
    }

    public static DbParameterCollection Create()
    {
        return new DbParameterCollection();
    }
}
