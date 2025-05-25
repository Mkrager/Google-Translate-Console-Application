using GoogleTranslate.App;
using GoogleTranslate.App.Contracts;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddGoogleTranslateServices();

var provider = services.BuildServiceProvider();

var consoleService = provider.GetRequiredService<ITranslationConsoleService>();

await consoleService.Start();
