using Google.Cloud.Translation.V2;
using GoogleTranslate.Application.Contracts.Infrastructure;
using GoogleTranslate.Application.DTOs;

namespace GoogleTranslate.Infrastructure.GoogleTranslate
{
    public class GoogleTranslateService : IGoogleTranslateService
    {
        private readonly TranslationClient _client;
        public GoogleTranslateService()
        {
            _client = TranslationClient.Create();
        }

        public async Task<List<LanguageResponse>> GetLanguagesList()
        {
            var response = await _client.ListLanguagesAsync("en");
            return response.Select(l => new LanguageResponse
            {
                Code = l.Code,
                Name = l.Name
            }).ToList();
        }

        public async Task<string> TranslateText(TranslateRequest translateRequest)
        {
            var response = await _client.TranslateTextAsync(translateRequest.TextToTranslate, translateRequest.targetLanguage, translateRequest.sourceLanguage);

            return response.TranslatedText;
        }
    }
}
