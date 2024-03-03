using System.Threading.Channels;
using Microsoft.Extensions.Hosting;

namespace Frank.EnterpriseFizzBuzz;

public class OutputService : BackgroundService
{
    private readonly ChannelReader<Output> _reader;

    /// <inheritdoc />
    public OutputService(ChannelReader<Output> reader)
    {
        _reader = reader;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var item in _reader.ReadAllAsync(stoppingToken))
        {
            var colorName = item.Color.ToMarkup();
            
            AnsiConsole.MarkupLine($"[grey]{DateTime.UtcNow:HH:mm:ss:fff}[/] [{colorName}]{item.Value}[/]");
        }
    }
}