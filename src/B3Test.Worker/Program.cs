using B3Test.MessageBus.MassTransit.Extensions;
using B3Test.Worker;
using B3Test.Worker.Extensions;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddMessageBusConfiguration(hostContext.Configuration);
    })
    .Build();

//Use application monitoring
host.ConfigureWorkerMonitoring();

await host.RunAsync();
