using System.Threading.Channels;
using Frank.EnterpriseFizzBuzz.Primitives;
using Microsoft.Extensions.Hosting;

namespace Frank.EnterpriseFizzBuzz.Services;

public class CountingService(ChannelWriter<Count> writer) : BackgroundService
{
    private ulong _count = 1;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await writer.WriteAsync(new Count { Value = _count++ }, stoppingToken);
            await Task.Delay(100, stoppingToken);
        }
    }
}