namespace Frank.EnterpriseFizzBuzz;

public class FooRule : IRule<ulong>
{
    public bool Evaluate(ulong input)
    {
        return input % 10 == 0;
    }

    /// <inheritdoc />
    public Output Output => new("Foo") { Color = Color.Green };
}