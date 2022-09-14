using Serilog;
using Serilog.Events;
using service;



string address = string.Join('\\', new[] { Directory.GetCurrentDirectory(), "WriteCoinLog.txt" });
Log.Logger=new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft",LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.File(address).CreateLogger();
try
{
    await ConfigWindowsService(args);
}
catch (Exception exception)
{
  
    Log.Information("windowsServiceConfigError");
}

async Task ConfigWindowsService(string[] strings)
{
    IHost host = Host.CreateDefaultBuilder(strings)
        .ConfigureServices(services => { services.AddHostedService<Worker>(); })
        .UseWindowsService()
        .UseSerilog()
        .Build();

    await host.RunAsync();
}

