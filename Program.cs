namespace ExpressionTest;

internal partial class Program
{
    static void Main(string[] args)
    {
        var sqlFilterBuilder = new SqlFilterBuilder<Person>();

        sqlFilterBuilder.EqualTo(p => p.LastName, "Jones");
        sqlFilterBuilder.GreaterThan(p => p.Age, 3);
        sqlFilterBuilder.StartsWith(p => p.FirstName, "F");

        var filter = sqlFilterBuilder.GetFilters();

        Console.WriteLine(filter);
    }
}
