
namespace Frank.EnterpriseFizzBuzz;

public class FizzRule : IRule<ulong>
{
    public bool Evaluate(ulong input)
    {
        return input % 3 == 0;
    }

    public Output Output { get; } = new("Fizz")
    {
        Color = Color.Red
    };
}