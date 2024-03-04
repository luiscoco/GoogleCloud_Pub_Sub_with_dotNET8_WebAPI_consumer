using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using PubSubReceiverApi.Controllers;
public class PubSubBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Assuming PubSubController has been adjusted to support this pattern
        await PubSubController.StartMessageProcessing(stoppingToken);
    }
}
