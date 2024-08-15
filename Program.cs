namespace ExpressionTest;

internal partial class Program
{
    static void Main(string[] args)
    {
        var sqlFilterBuilder = new SqlFilterBuilder<Person>();

        sqlFilterBuilder.EqualTo(p => p.LastName, "Jones");
        sqlFilterBuilder.GreaterThanOrEqualTo(p => p.Age, 18);
        sqlFilterBuilder.LessThanOrEqualTo(p => p.Age, 40);
        sqlFilterBuilder.StartsWith(p => p.FirstName, "J");
        sqlFilterBuilder.In(p => p.FirstName, new List<string> { "Joe", "Jane", "Jim" });

        var filter = sqlFilterBuilder.GetFilters();

        Console.WriteLine(filter);
    }
}
