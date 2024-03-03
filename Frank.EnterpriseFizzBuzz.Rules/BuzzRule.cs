using Frank.EnterpriseFizzBuzz.Primitives;

namespace Frank.EnterpriseFizzBuzz.Rules;

public class BuzzRule : IRule<ulong>
{
    public bool Evaluate(ulong input)
    {
        return input % 5 == 0;
    }

    public Output Output { get; } = new("Buzz")
    {
        Color = Color.Blue
    };
}