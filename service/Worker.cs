using Serilog;

namespace service;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    
    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            var writeCoin = new writeCoin_Lib.WriteCoin();
            await Task.Delay(1000*60, stoppingToken);
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
      
        Log.Information("Start Service WriteCoin");
        Log.CloseAndFlush();
        return base.StopAsync(cancellationToken);   
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        Log.Information("Start Service WriteCoin");
        return base.StartAsync(cancellationToken);
    }
}
