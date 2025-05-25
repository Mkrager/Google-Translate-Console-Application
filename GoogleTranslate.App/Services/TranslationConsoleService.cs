using GoogleTranslate.App.Contracts;
using GoogleTranslate.App.Models;

namespace GoogleTranslate.App.Services
{
    public class TranslationConsoleService : ITranslationConsoleService
    {
        private readonly IGoogleTranslatorService _googleTranslatorService;

        public TranslationConsoleService(IGoogleTranslatorService googleTranslatorService)
        {
            _googleTranslatorService = googleTranslatorService;
        }

        public async Task Start()
        {
            await DisplayLanguages();

            var languages = await _googleTranslatorService.GetLanguagesList();

            var textToTranslate = GetTextToTranslate();

            var sourceLanguage = GetSourceLanguage(languages);

            var targetLanguage = GetTargetLanguages(languages);

            await Translate(textToTranslate, sourceLanguage, targetLanguage);
        }

        private async Task Translate(string textToTranslate, string sourceLanguage, List<string> targetLanguage)
        {
            foreach (var language in targetLanguage)
            {
                try
                {
                    var response = await _googleTranslatorService.TranslateText(sourceLanguage, language, textToTranslate);
                    Console.WriteLine(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to translate to {language}. Error: {ex.Message}");
                }
            }
        }

        private async Task DisplayLanguages()
        {
            var languages = await _googleTranslatorService.GetLanguagesList();

            for (int i = 0; i < languages.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {languages[i].Name}, Code: {languages[i].Code}");
            }
            Console.WriteLine();
        }

        private string GetTextToTranslate()
        {
            string textToTranslate;

            Console.Write("Enter text to translate: ");

            do
            {
                textToTranslate = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(textToTranslate))
                {
                    Console.WriteLine("Error empty input. Try again: ");
                    continue;
                }

                break;
            } while (true);

            return textToTranslate;
        }

        private string GetSourceLanguage(List<LanguageViewModel> languages)
        {
            int selectedIndex;
            string input;

            Console.Write("Enter index of source language: ");

            do
            {
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out selectedIndex) || selectedIndex < 1 || selectedIndex > languages.Count)
                {
                    Console.Write("Invalid input, try again: ");
                    continue;
                }

                break;
            } while (true);

            return languages[selectedIndex - 1].Code;
        }

        private List<string> GetTargetLanguages(List<LanguageViewModel> languages)
        {
            var targetLanguages = new List<string>();
            string input;
            int selectedIndex;

            Console.Write("Enter indexes of target languages: ");

            do
            {
                input = Console.ReadLine();

                if (input == "c" || input == "C")
                    break;

                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out selectedIndex) || selectedIndex < 1 || selectedIndex > languages.Count)
                {
                    Console.Write("Error empty input, try again: ");
                    continue;
                }

                targetLanguages.Add(languages[selectedIndex - 1].Code);

                if (targetLanguages == null)
                {
                    Console.WriteLine("Error empty input, try again: ");
                    continue;
                }
                Console.Write("Type 'c' for countine or input another language: ");
                continue;
            } while (true);

            return targetLanguages;
        }

    }
}
