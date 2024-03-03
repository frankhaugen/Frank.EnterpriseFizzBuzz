using System.Text;
using System.Threading.Channels;
using Frank.EnterpriseFizzBuzz.Primitives;
using Microsoft.Extensions.Hosting;

namespace Frank.EnterpriseFizzBuzz.Services;

public class RuleService : BackgroundService
{
    private readonly ChannelReader<Count> _reader;
    private readonly ChannelWriter<Output> _writer;
    private readonly RuleEvaluatorService<ulong> _ruleEvaluatorService;
    
    public RuleService(ChannelReader<Count> reader, ChannelWriter<Output> writer, RuleEvaluatorService<ulong> ruleEvaluatorService)
    {
        _reader = reader;
        _writer = writer;
        _ruleEvaluatorService = ruleEvaluatorService;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var item in _reader.ReadAllAsync(stoppingToken))
        {
            var stringBuilder = new StringBuilder();
            var rules = _ruleEvaluatorService.Evaluate(item.Value);

            if (rules == null || !rules.Any())
            {
                await _writer.WriteAsync(new(item.Value.ToString()), stoppingToken);
            }
            else
            {
                foreach (var rule in rules) stringBuilder.Append($"{rule.Output.Value}");
            
                await _writer.WriteAsync(new(stringBuilder.ToString())
                {
                    Color = rules.Select(rule => rule.Output.Color).Average()
                }, stoppingToken);
            }
        }
    }
}