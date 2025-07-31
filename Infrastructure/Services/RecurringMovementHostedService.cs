using Application.Interfaces.UseCases.RecurringMovements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class RecurringMovementHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public RecurringMovementHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var generator = scope.ServiceProvider.GetRequiredService<IGenerateRecurringMovements>();
            await generator.ExecuteAsync();

            await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
        }
    }
}

