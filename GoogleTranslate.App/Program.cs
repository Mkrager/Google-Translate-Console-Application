using GoogleTranslate.App;
using GoogleTranslate.App.Contracts;
using GoogleTranslate.App.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddGoogleTranslateServices();

services.AddHttpClient<IGoogleTranslatorService, GoogleTranslatorService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7067/api/GoogleTranslate/");
});

var provider = services.BuildServiceProvider();

var translationConsoleService = provider.GetRequiredService<ITranslationConsoleService>();

await translationConsoleService.Start();
