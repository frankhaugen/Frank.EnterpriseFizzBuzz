using Frank.EnterpriseFizzBuzz.Primitives;

namespace Frank.EnterpriseFizzBuzz.Hosting;

public interface IRuleSetBuilder<T>
{
    void Add<TRule>() where TRule : class, IRule<T>;
}