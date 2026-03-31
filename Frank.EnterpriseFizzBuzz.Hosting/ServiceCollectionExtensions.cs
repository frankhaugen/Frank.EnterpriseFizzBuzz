using Frank.Channels.DependencyInjection;
using Frank.EnterpriseFizzBuzz.Primitives;
using Frank.EnterpriseFizzBuzz.Rules;
using Frank.EnterpriseFizzBuzz.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.EnterpriseFizzBuzz.Hosting;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFizzBuzz<T>(this IServiceCollection services, Action<IRuleSetBuilder<T>> configureRules)
    {
        var ruleSet = new RuleSetBuilder<T>(services);
        configureRules(ruleSet);
        services.AddSingleton<IRuleSetBuilder<T>>(ruleSet);
        services.AddSingleton<RuleEvaluatorService<T>>();
        services.AddChannel<Count>();
        services.AddChannel<Output>();
        services.AddHostedService<CountingService>();
        services.AddHostedService<RuleService>();
        services.AddHostedService<OutputService>();
        return services;
    }
}