using GoogleTranslate.App;
using GoogleTranslate.App.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var services = new ServiceCollection();

services.AddGoogleTranslateServices();

var provider = services.BuildServiceProvider();

var consoleService = provider.GetRequiredService<ITranslationConsoleService>();

await consoleService.Start();
