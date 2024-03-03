namespace Frank.EnterpriseFizzBuzz.Primitives;

public interface IRule<T>
{
    bool Evaluate(T input);
    
    Output Output { get; }
}