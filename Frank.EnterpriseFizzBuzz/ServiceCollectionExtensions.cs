using Frank.Channels.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.EnterpriseFizzBuzz;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFizzBuzz(this IServiceCollection services)
    {
        services.AddSingleton<IRule<ulong>, FizzRule>();
        services.AddSingleton<IRule<ulong>, BuzzRule>();
        services.AddSingleton<IRule<ulong>, FooRule>();
        
        services.AddChannel<Count>();
        services.AddChannel<Output>();
        services.AddSingleton<RuleEvaluatorService<ulong>>();
        services.AddHostedService<CountingService>();
        services.AddHostedService<RuleEngine>();
        services.AddHostedService<OutputService>();
        return services;
    }
}