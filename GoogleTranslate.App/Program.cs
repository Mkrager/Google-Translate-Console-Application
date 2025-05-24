using GoogleTranslate.App;
using GoogleTranslate.App.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var credentialsPath = configuration["Google:CredentialsPath"];

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsPath);

var services = new ServiceCollection();

services.AddGoogleTranslateServices();

var provider = services.BuildServiceProvider();

var translatorService = provider.GetRequiredService<IGoogleTranslatorService>();

var translationConsloleHandler = new TranslationConsoleHandler(translatorService);

await translationConsloleHandler.Start();