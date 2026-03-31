using Frank.EnterpriseFizzBuzz.Primitives;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.EnterpriseFizzBuzz.Hosting;

public class RuleSetBuilder<T> : IRuleSetBuilder<T>
{
    private readonly IServiceCollection _services;

    public RuleSetBuilder(IServiceCollection services)
    {
        _services = services;
    }

    /// <inheritdoc />
    public void Add<TRule>() where TRule : class, IRule<T>
    {
        _services.AddSingleton<IRule<T>, TRule>();
    }
}