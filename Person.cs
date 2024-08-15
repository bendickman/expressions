namespace ExpressionTest;

internal partial class Program
{
    public class Person : IPerson
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}
