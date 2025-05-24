using Google.Cloud.Translation.V2;
using GoogleTranslate.App.Contracts;

namespace GoogleTranslate.App.Services
{
    public class GoogleTranslatorService : IGoogleTranslatorService
    {
        private readonly TranslationClient _client;
        public GoogleTranslatorService()
        {
            _client = TranslationClient.Create();
        }

        public async Task<List<Language>> GetLanguagesList()
        {
            var response = await _client.ListLanguagesAsync("en");
            return response.ToList();
        }

        public async Task<string> TranslateText(string sourceLanguage, string targetLanguage, string textToTranslate)
        {
            try
            {
                var response = await _client.TranslateTextAsync(textToTranslate, targetLanguage, sourceLanguage);

                return response.TranslatedText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
