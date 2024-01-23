using WorkerService2;
using WorkerService2.contracts;
using WorkerService2.services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
        .AddSingleton<IEmail, Email>()
        .AddSingleton<IHttpService, HttpService>();
    })
    .Build();

host.Run();