using GoogleTranslate.App.Contracts;
using GoogleTranslate.App.Models;
using System.Text.Json;

namespace GoogleTranslate.App.Services
{
    public class GoogleTranslatorService : IGoogleTranslatorService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public GoogleTranslatorService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        public async Task<List<LanguageViewModel>> GetLanguagesList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7067/api/GoogleTranslate/languages");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var languageList = JsonSerializer.Deserialize<List<LanguageViewModel>>(responseContent, _jsonOptions);

                return languageList;
            }

            return new List<LanguageViewModel>();
        }

        public Task<string> TranslateText(string sourceLanguage, string targetLanguage, string textToTranslate)
        {
            throw new NotImplementedException();
        }
    }
}
