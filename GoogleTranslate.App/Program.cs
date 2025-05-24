using GoogleTranslate.App;
using GoogleTranslate.App.Contracts;
using Microsoft.Extensions.DependencyInjection;

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\Users\Smaga\Downloads\light-sunup-460810-q7-a2928fd47886.json");

var services = new ServiceCollection();

services.AddGoogleTranslateServices();

var provider = services.BuildServiceProvider();

var translatorService = provider.GetRequiredService<IGoogleTranslatorService>();

var translationConsloleHandler = new TranslationConsoleHandler(translatorService);

await translationConsloleHandler.Start();