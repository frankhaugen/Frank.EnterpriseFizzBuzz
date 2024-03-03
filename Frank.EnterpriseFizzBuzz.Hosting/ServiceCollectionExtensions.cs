using Frank.Channels.DependencyInjection;
using Frank.EnterpriseFizzBuzz.Primitives;
using Frank.EnterpriseFizzBuzz.Rules;
using Frank.EnterpriseFizzBuzz.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.EnterpriseFizzBuzz.Hosting;

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
        services.AddHostedService<RuleService>();
        services.AddHostedService<OutputService>();
        return services;
    }
}