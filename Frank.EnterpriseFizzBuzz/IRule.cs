namespace Frank.EnterpriseFizzBuzz;

public interface IRule<T>
{
    bool Evaluate(T input);
    
    Output Output { get; }
}