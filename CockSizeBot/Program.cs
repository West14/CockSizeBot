using BotFramework;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTelegramBot();
    })
    .Build();

await host.RunAsync();
