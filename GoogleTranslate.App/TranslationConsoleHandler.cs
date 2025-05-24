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
    }
}
