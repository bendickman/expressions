using System.Linq.Expressions;

namespace ExpressionTest;

internal class Program
{
    static void Main(string[] args)
    {
        var result = SomeFunction<Person>(d => d.LastName);
        var result2 = SomeFunction<Person>(d => d.FirstName);

        Console.WriteLine(result);
        Console.WriteLine(result2);
    }

    private static string SomeFunction<IPerson>(Expression<Func<IPerson, object>> expression)
    {
        var fieldName = GetFieldName(expression);

        //dummy count expression for demo purpose
        return $"COUNT({fieldName})";
    }

    private static string GetFieldName(Expression expression)
    {
        var ex = expression.ToString();

        return string.Join("/", ex.Split('.').Skip(1));
    }

    public interface IPerson
    {
        int Age { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }

    public class Person : IPerson
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}
