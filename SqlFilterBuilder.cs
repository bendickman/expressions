using System.Linq.Expressions;

namespace ExpressionTest;

public class SqlFilterBuilder<TPerson>
{
    private readonly List<string> _filters = new List<string>();

    public SqlFilterBuilder<TPerson> GreaterThan<TValue>(
        Expression<Func<TPerson, TValue>> field,
        object value)
    {
        _filters.Add($"{GetFieldName(field)} > {value}");

        return this;
    }

    public SqlFilterBuilder<TPerson> In<TValue>(
        Expression<Func<TPerson, TValue>> field,
        IEnumerable<TValue>? values)
    {
        if (!values?.Any() ?? true)
        {
            return this;
        }

        if (values is IEnumerable<string>)
        {
            values = values.Select(v => $"'{v}'").ToList() as IEnumerable<TValue>;
        }

        _filters.Add($"{GetFieldName(field)} IN({string.Join(",", values!)})");

        return this;
    }

    public SqlFilterBuilder<TPerson> EqualTo<TValue>(
        Expression<Func<TPerson, TValue>> field,
        object value)
    {
        if (value is string)
        {
            value = $"'{value}'";
        }

        _filters.Add($"{GetFieldName(field)} == {value}");

        return this;
    }

    public SqlFilterBuilder<TPerson> StartsWith<TValue>(
        Expression<Func<TPerson, TValue>> field,
        object value)
    {
        _filters.Add($"{GetFieldName(field)} LIKE '{value}%'");

        return this;
    }

    public string GetFilters()
    {
        var result = string.Join("\nAND ", _filters);

        return $"WHERE {result}";
    }

    private static string GetFieldName(Expression expression)
    {
        var ex = expression.ToString();

        return string.Join("/", ex.Split('.').Skip(1));
    }
}
