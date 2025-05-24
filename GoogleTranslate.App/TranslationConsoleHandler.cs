using Google.Cloud.Translation.V2;
using GoogleTranslate.App.Contracts;

namespace GoogleTranslate.App
{
    public class TranslationConsoleHandler
    {
        private readonly IGoogleTranslatorService _googleTranslatorService;

        public TranslationConsoleHandler(IGoogleTranslatorService googleTranslatorService)
        {
            _googleTranslatorService = googleTranslatorService;
        }

        public async Task DisplayLanguages()
        {
            var languages = await _googleTranslatorService.GetLanguagesList();

            for (int i = 0; i < languages.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {languages[i].Name}, Code: {languages[i].Code}");
            }
            Console.WriteLine();
        }

        public string GetTextToTranslate()
        {
            string textToTranslate;

            Console.WriteLine("Enter text to translate: ");

            do
            {
                textToTranslate = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(textToTranslate))
                {
                    Console.WriteLine("Error empty input");
                    continue;
                }

                break;
            } while (true);

            return textToTranslate;
        }


    }
}
