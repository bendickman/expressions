namespace ExpressionTest;

internal partial class Program
{
    static void Main(string[] args)
    {
        var sqlFilterBuilder = new SqlFilterBuilder<Person>();

        sqlFilterBuilder.EqualTo(p => p.LastName, "Jones");
        sqlFilterBuilder.GreaterThan(p => p.Age, 3);
        sqlFilterBuilder.StartsWith(p => p.FirstName, "J");
        sqlFilterBuilder.In(p => p.FirstName, new List<string> { "Joe", "Jane", "Jim" });

        var filter = sqlFilterBuilder.GetFilters();

        Console.WriteLine(filter);
    }
}
